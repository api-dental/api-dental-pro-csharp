using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using APIDentalPro.Core;
using APIDentalPro.Models.Payer;

namespace APIDentalPro.Services.Payer;

public sealed class PayerService : IPayerService
{
    public IPayerService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PayerService(this._client.WithOptions(modifier));
    }

    readonly IAPIDentalProClient _client;

    public PayerService(IAPIDentalProClient client)
    {
        _client = client;
    }

    public async Task<List<PayerListResponse>> List(PayerListParams? parameters = null)
    {
        parameters ??= new();

        HttpRequest<PayerListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        using var response = await this._client.Execute(request).ConfigureAwait(false);
        var payers = await response.Deserialize<List<PayerListResponse>>().ConfigureAwait(false);
        if (this._client.ResponseValidation)
        {
            foreach (var item in payers)
            {
                item.Validate();
            }
        }
        return payers;
    }
}
