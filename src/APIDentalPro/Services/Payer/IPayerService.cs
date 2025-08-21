using System.Collections.Generic;
using System.Threading.Tasks;
using APIDentalPro.Models.Payer;

namespace APIDentalPro.Services.Payer;

public interface IPayerService
{
    /// <summary>
    /// List Payers
    /// </summary>
    Task<List<PayerListResponse>> List(PayerListParams? parameters = null);
}
