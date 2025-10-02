using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using APIDentalPro.Core;
using APIDentalPro.Models.Eligibility;

namespace APIDentalPro.Services.Eligibility;

public sealed class EligibilityService : IEligibilityService
{
    readonly IAPIDentalProClient _client;

    public EligibilityService(IAPIDentalProClient client)
    {
        _client = client;
    }

    public async Task<JsonElement> Request(EligibilityRequestParams parameters)
    {
        HttpRequest<EligibilityRequestParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        return await response.Deserialize<JsonElement>().ConfigureAwait(false);
    }
}
