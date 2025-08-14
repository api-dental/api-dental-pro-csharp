using System.Text.Json;
using System.Threading.Tasks;
using APIDentalPro.Models.Eligibility;

namespace APIDentalPro.Services.Eligibility;

public interface IEligibilityService
{
    /// <summary>
    /// Request Eligibility
    /// </summary>
    Task<JsonElement> Request(EligibilityRequestParams parameters);
}
