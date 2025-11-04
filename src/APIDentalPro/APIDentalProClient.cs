using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using APIDentalPro.Core;
using APIDentalPro.Exceptions;
using APIDentalPro.Services.ClearCoverage;
using APIDentalPro.Services.Eligibility;
using APIDentalPro.Services.Payer;

namespace APIDentalPro;

public sealed class APIDentalProClient : IAPIDentalProClient
{
    readonly ClientOptions _options = new();

    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    public Uri BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    public TimeSpan Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    public string APIKey
    {
        get { return this._options.APIKey; }
        init { this._options.APIKey = value; }
    }

    public string? SDKSource
    {
        get { return this._options.SDKSource; }
        init { this._options.SDKSource = value; }
    }

    public string? SDKLang
    {
        get { return this._options.SDKLang; }
        init { this._options.SDKLang = value; }
    }

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
        using CancellationTokenSource cts = new(this.Timeout);
        HttpResponseMessage responseMessage;
        try
        {
            responseMessage = await this
                .HttpClient.SendAsync(
                    requestMessage,
                    HttpCompletionOption.ResponseHeadersRead,
                    cts.Token
                )
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
