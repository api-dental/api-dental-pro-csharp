using System;
using System.Net.Http;
using System.Threading.Tasks;
using APIDentalPro.Core;
using APIDentalPro.Services.ClearCoverage;
using APIDentalPro.Services.Eligibility;
using APIDentalPro.Services.Payer;

namespace APIDentalPro;

public interface IAPIDentalProClient
{
    HttpClient HttpClient { get; init; }

    Uri BaseUrl { get; init; }

    string APIKey { get; init; }

    string? SDKSource { get; init; }

    string? SDKLang { get; init; }

    IEligibilityService Eligibility { get; }

    IClearCoverageService ClearCoverage { get; }

    IPayerService Payer { get; }

    Task<HttpResponse> Execute<T>(HttpRequest<T> request)
        where T : ParamsBase;
}
