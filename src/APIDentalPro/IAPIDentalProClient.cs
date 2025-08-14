using System;
using ClearCoverage = APIDentalPro.Services.ClearCoverage;
using Eligibility = APIDentalPro.Services.Eligibility;
using Http = System.Net.Http;

namespace APIDentalPro;

public interface IAPIDentalProClient
{
    Http::HttpClient HttpClient { get; init; }

    Uri BaseUrl { get; init; }

    string APIKey { get; init; }

    Eligibility::IEligibilityService Eligibility { get; }

    ClearCoverage::IClearCoverageService ClearCoverage { get; }

    global::APIDentalPro.Services.Payer.IPayerService Payer { get; }
}
