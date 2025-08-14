using System.Text.Json;
using System.Threading.Tasks;
using APIDentalPro.Models.ClearCoverage;

namespace APIDentalPro.Services.ClearCoverage;

public interface IClearCoverageService
{
    /// <summary>
    /// Clear Coverage
    /// </summary>
    Task<JsonElement> Request(ClearCoverageRequestParams parameters);
}
