using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using APIDentalPro.Core;
using APIDentalPro.Models.Eligibility;

namespace APIDentalPro.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IEligibilityService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEligibilityService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Request Eligibility
    /// </summary>
    Task<JsonElement> Request(
        EligibilityRequestParams parameters,
        CancellationToken cancellationToken = default
    );
}
