using System;
using System.Net.Http;
using APIDentalPro = APIDentalPro;

namespace APIDentalPro.Models.Payer;

/// <summary>
/// List Payers
/// </summary>
public sealed record class PayerListParams : APIDentalPro::ParamsBase
{
    public override Uri Url(APIDentalPro::IAPIDentalProClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/Payer")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public void AddHeadersToRequest(
        HttpRequestMessage request,
        APIDentalPro::IAPIDentalProClient client
    )
    {
        APIDentalPro::ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            APIDentalPro::ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}
