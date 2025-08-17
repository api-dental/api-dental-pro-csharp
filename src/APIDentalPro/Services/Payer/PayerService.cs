using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using APIDentalPro.Models.Payer;

namespace APIDentalPro.Services.Payer;

public sealed class PayerService : IPayerService
{
    readonly IAPIDentalProClient _client;

    public PayerService(IAPIDentalProClient client)
    {
        _client = client;
    }

    public async Task<List<PayerListResponse>> List(PayerListParams parameters)
    {
        using HttpRequestMessage request = new(HttpMethod.Get, parameters.Url(this._client));
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

        return JsonSerializer.Deserialize<List<PayerListResponse>>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
