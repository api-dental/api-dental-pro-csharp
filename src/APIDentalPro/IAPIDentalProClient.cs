using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using APIDentalPro.Core;
using APIDentalPro.Services;

namespace APIDentalPro;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAPIDentalProClient
{
    HttpClient HttpClient { get; init; }

    Uri BaseUrl { get; init; }

    bool ResponseValidation { get; init; }

    int? MaxRetries { get; init; }

    TimeSpan? Timeout { get; init; }

    string APIKey { get; init; }

    string? SDKSource { get; init; }

    string? SDKLang { get; init; }

    IAPIDentalProClient WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IEligibilityService Eligibility { get; }

    IClearCoverageService ClearCoverage { get; }

    IPayerService Payer { get; }

    Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase;
}
