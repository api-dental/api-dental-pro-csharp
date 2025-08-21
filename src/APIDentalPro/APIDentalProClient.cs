using System;
using System.Net.Http;
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
        ?? throw new ArgumentNullException(nameof(APIKey))
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

    public APIDentalProClient()
    {
        _eligibility = new(() => new EligibilityService(this));
        _clearCoverage = new(() => new ClearCoverageService(this));
        _payer = new(() => new PayerService(this));
    }
}
