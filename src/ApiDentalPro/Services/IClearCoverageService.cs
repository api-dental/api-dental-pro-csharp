using System;
using System.Threading;
using System.Threading.Tasks;
using ApiDentalPro.Core;
using ApiDentalPro.Models.ClearCoverage;

namespace ApiDentalPro.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IClearCoverageService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IClearCoverageServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IClearCoverageService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Submit an enhanced eligibility and benefits verification request via Vyne
    /// ClearCoverage. Returns enriched, standardized, and normalized data relevant for
    /// dental use cases with deep benefit insights across supported payers.
    /// </summary>
    Task<ClearCoverageRequestResponse> Request(
        ClearCoverageRequestParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IClearCoverageService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IClearCoverageServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IClearCoverageServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /ClearCoverage</c>, but is otherwise the
    /// same as <see cref="IClearCoverageService.Request(ClearCoverageRequestParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ClearCoverageRequestResponse>> Request(
        ClearCoverageRequestParams parameters,
        CancellationToken cancellationToken = default
    );
}
