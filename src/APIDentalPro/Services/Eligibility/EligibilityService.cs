using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
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
        using HttpRequestMessage request = new(HttpMethod.Post, parameters.Url(this._client))
        {
            Content = parameters.BodyContent(),
        };
        parameters.AddHeadersToRequest(request, this._client);
        using HttpResponseMessage response = await this
            ._client.HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<JsonElement>(
            await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
            ModelBase.SerializerOptions
        );
    }
}
