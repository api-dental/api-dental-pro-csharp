using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using APIDentalPro.Core;
using APIDentalPro.Models.ClearCoverage;

namespace APIDentalPro.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IClearCoverageService
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IClearCoverageService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Clear Coverage
    /// </summary>
    Task<JsonElement> Request(
        ClearCoverageRequestParams parameters,
        CancellationToken cancellationToken = default
    );
}
