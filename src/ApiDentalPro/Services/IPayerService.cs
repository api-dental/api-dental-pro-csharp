using System;
using System.Threading;
using System.Threading.Tasks;
using ApiDentalPro.Core;
using ApiDentalPro.Models.Payer;

namespace ApiDentalPro.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IPayerService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPayerServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPayerService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieve the full list of supported dental insurance payers with their IDs,
    /// names, features, and status. No sensitive data is required. Use payer IDs
    /// from this list when making Eligibility or ClearCoverage requests.
    /// </summary>
    Task<PayerListResponse> List(
        PayerListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IPayerService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPayerServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPayerServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /Payer`, but is otherwise the
    /// same as <see cref="IPayerService.List(PayerListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PayerListResponse>> List(
        PayerListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
