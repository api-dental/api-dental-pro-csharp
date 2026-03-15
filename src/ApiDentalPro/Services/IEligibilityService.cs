using System;
using System.Threading;
using System.Threading.Tasks;
using ApiDentalPro.Core;
using ApiDentalPro.Models.Eligibility;

namespace ApiDentalPro.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IEligibilityService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEligibilityServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEligibilityService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Submit a real-time eligibility and benefits verification request for a dental
    /// insurance subscriber. Returns coverage details, deductibles, maximums, and
    /// benefit information from the payer.
    /// </summary>
    Task<EligibilityRequestResponse> Request(
        EligibilityRequestParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IEligibilityService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEligibilityServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEligibilityServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /Eligibility`, but is otherwise the
    /// same as <see cref="IEligibilityService.Request(EligibilityRequestParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EligibilityRequestResponse>> Request(
        EligibilityRequestParams parameters,
        CancellationToken cancellationToken = default
    );
}
