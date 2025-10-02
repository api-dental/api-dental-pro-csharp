using System;
using System.Net.Http;
using System.Threading.Tasks;
using APIDentalPro.Core;
using APIDentalPro.Exceptions;
using APIDentalPro.Services.ClearCoverage;
using APIDentalPro.Services.Eligibility;
using APIDentalPro.Services.Payer;

namespace APIDentalPro;

public sealed class APIDentalProClient : IAPIDentalProClient
{
    public HttpClient HttpClient { get; init; } = new();

    Lazy<Uri> _baseUrl = new(() =>
        new Uri(
            Environment.GetEnvironmentVariable("API_DENTAL_PRO_BASE_URL")
                ?? "https://wg.api.dental/rest"
        )
    );
    public Uri BaseUrl
    {
        get { return _baseUrl.Value; }
        init { _baseUrl = new(() => value); }
    }

    Lazy<string> _apiKey = new(() =>
        Environment.GetEnvironmentVariable("API_DENTAL_API_KEY")
        ?? throw new APIDentalProInvalidDataException(
            string.Format("{0} cannot be null", nameof(APIKey)),
            new ArgumentNullException(nameof(APIKey))
        )
    );
    public string APIKey
    {
        get { return _apiKey.Value; }
        init { _apiKey = new(() => value); }
    }

    public string? SDKSource { get; init; } = "api-dental-sdk";

    public string? SDKLang { get; init; } = "";

    readonly Lazy<IEligibilityService> _eligibility;
    public IEligibilityService Eligibility
    {
        get { return _eligibility.Value; }
    }

    readonly Lazy<IClearCoverageService> _clearCoverage;
    public IClearCoverageService ClearCoverage
    {
        get { return _clearCoverage.Value; }
    }

    readonly Lazy<IPayerService> _payer;
    public IPayerService Payer
    {
        get { return _payer.Value; }
    }

    public async Task<HttpResponse> Execute<T>(HttpRequest<T> request)
        where T : ParamsBase
    {
        using HttpRequestMessage requestMessage = new(request.Method, request.Params.Url(this))
        {
            Content = request.Params.BodyContent(),
        };
        request.Params.AddHeadersToRequest(requestMessage, this);
        HttpResponseMessage responseMessage;
        try
        {
            responseMessage = await this
                .HttpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead)
                .ConfigureAwait(false);
        }
        catch (HttpRequestException e1)
        {
            throw new APIDentalProIOException("I/O exception", e1);
        }
        if (!responseMessage.IsSuccessStatusCode)
        {
            try
            {
                throw APIDentalProExceptionFactory.CreateApiException(
                    responseMessage.StatusCode,
                    await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false)
                );
            }
            catch (HttpRequestException e)
            {
                throw new APIDentalProIOException("I/O Exception", e);
            }
            finally
            {
                responseMessage.Dispose();
            }
        }
        return new() { Message = responseMessage };
    }

    public APIDentalProClient()
    {
        _eligibility = new(() => new EligibilityService(this));
        _clearCoverage = new(() => new ClearCoverageService(this));
        _payer = new(() => new PayerService(this));
    }
}
