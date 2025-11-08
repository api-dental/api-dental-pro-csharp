using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using APIDentalPro.Core;
using APIDentalPro.Models.Eligibility;

namespace APIDentalPro.Services.Eligibility;

public interface IEligibilityService
{
    IEligibilityService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Request Eligibility
    /// </summary>
    Task<JsonElement> Request(
        EligibilityRequestParams parameters,
        CancellationToken cancellationToken = default
    );
}
