using System;
using ClearCoverage = APIDentalPro.Services.ClearCoverage;
using Eligibility = APIDentalPro.Services.Eligibility;
using Http = System.Net.Http;

namespace APIDentalPro;

public sealed class APIDentalProClient : IAPIDentalProClient
{
    public Http::HttpClient HttpClient { get; init; } = new();

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

    readonly Lazy<Eligibility::IEligibilityService> _eligibility;
    public Eligibility::IEligibilityService Eligibility
    {
        get { return _eligibility.Value; }
    }

    readonly Lazy<ClearCoverage::IClearCoverageService> _clearCoverage;
    public ClearCoverage::IClearCoverageService ClearCoverage
    {
        get { return _clearCoverage.Value; }
    }

    readonly Lazy<global::APIDentalPro.Services.Payer.IPayerService> _payer;
    public global::APIDentalPro.Services.Payer.IPayerService Payer
    {
        get { return _payer.Value; }
    }

    public APIDentalProClient()
    {
        _eligibility = new(() => new Eligibility::EligibilityService(this));
        _clearCoverage = new(() => new ClearCoverage::ClearCoverageService(this));
        _payer = new(() => new global::APIDentalPro.Services.Payer.PayerService(this));
    }
}
