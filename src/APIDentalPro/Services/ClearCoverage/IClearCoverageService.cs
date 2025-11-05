using System;
using System.Text.Json;
using System.Threading.Tasks;
using APIDentalPro.Core;
using APIDentalPro.Models.ClearCoverage;

namespace APIDentalPro.Services.ClearCoverage;

public interface IClearCoverageService
{
    IClearCoverageService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Clear Coverage
    /// </summary>
    Task<JsonElement> Request(ClearCoverageRequestParams parameters);
}
