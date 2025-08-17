using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using APIDentalPro.Models.ClearCoverage;

namespace APIDentalPro.Services.ClearCoverage;

public sealed class ClearCoverageService : IClearCoverageService
{
    readonly IAPIDentalProClient _client;

    public ClearCoverageService(IAPIDentalProClient client)
    {
        _client = client;
    }

    public async Task<JsonElement> Request(ClearCoverageRequestParams parameters)
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
