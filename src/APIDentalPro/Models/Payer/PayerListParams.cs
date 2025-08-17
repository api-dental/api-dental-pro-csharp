using System;
using System.Net.Http;

namespace APIDentalPro.Models.Payer;

/// <summary>
/// List Payers
/// </summary>
public sealed record class PayerListParams : ParamsBase
{
    public override Uri Url(IAPIDentalProClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/Payer")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public void AddHeadersToRequest(HttpRequestMessage request, IAPIDentalProClient client)
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
