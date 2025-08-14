using System.Threading.Tasks;
using APIDentalPro.Models.Payer;
using Generic = System.Collections.Generic;

namespace APIDentalPro.Services.Payer;

public interface IPayerService
{
    /// <summary>
    /// List Payers
    /// </summary>
    Task<Generic::List<PayerListResponse>> List(PayerListParams parameters);
}
