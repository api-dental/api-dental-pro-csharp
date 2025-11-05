using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIDentalPro.Core;
using APIDentalPro.Models.Payer;

namespace APIDentalPro.Services.Payer;

public interface IPayerService
{
    IPayerService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// List Payers
    /// </summary>
    Task<List<PayerListResponse>> List(PayerListParams? parameters = null);
}
