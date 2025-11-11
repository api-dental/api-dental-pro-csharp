using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using APIDentalPro.Core;
using APIDentalPro.Models.Payer;

namespace APIDentalPro.Services;

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
