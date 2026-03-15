using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using APIDentalPro.Core;
using APIDentalPro.Models.Payer;

namespace APIDentalPro.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IPayerService
{
    IPayerService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// List Payers
    /// </summary>
    Task<List<PayerListResponse>> List(
        PayerListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
