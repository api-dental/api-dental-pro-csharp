using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using APIDentalPro.Models.Payer;
using APIDentalPro = APIDentalPro;
using Generic = System.Collections.Generic;

namespace APIDentalPro.Services.Payer;

public sealed class PayerService : IPayerService
{
    readonly APIDentalPro::IAPIDentalProClient _client;

    public PayerService(APIDentalPro::IAPIDentalProClient client)
    {
        _client = client;
    }

    public async Task<Generic::List<PayerListResponse>> List(PayerListParams parameters)
    {
        using HttpRequestMessage request = new(HttpMethod.Get, parameters.Url(this._client));
        parameters.AddHeadersToRequest(request, this._client);
        using HttpResponseMessage response = await this
            ._client.HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
            .ConfigureAwait(false);
        if (!response.IsSuccessStatusCode)
        {
            throw new APIDentalPro::HttpException(
                response.StatusCode,
                await response.Content.ReadAsStringAsync().ConfigureAwait(false)
            );
        }

        return JsonSerializer.Deserialize<Generic::List<PayerListResponse>>(
                await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                APIDentalPro::ModelBase.SerializerOptions
            ) ?? throw new NullReferenceException();
    }
}
