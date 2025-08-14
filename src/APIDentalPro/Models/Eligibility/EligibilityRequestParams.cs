using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using APIDentalPro = APIDentalPro;
using EligibilityRequestParamsProperties = APIDentalPro.Models.Eligibility.EligibilityRequestParamsProperties;

namespace APIDentalPro.Models.Eligibility;

/// <summary>
/// Request Eligibility
/// </summary>
public sealed record class EligibilityRequestParams : APIDentalPro::ParamsBase
{
    public Dictionary<string, JsonElement> BodyProperties { get; set; } = [];

    public required EligibilityRequestParamsProperties::Payer Payer
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("payer", out JsonElement element))
                throw new ArgumentOutOfRangeException("payer", "Missing required argument");

            return JsonSerializer.Deserialize<EligibilityRequestParamsProperties::Payer>(
                    element,
                    APIDentalPro::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("payer");
        }
        set { this.BodyProperties["payer"] = JsonSerializer.SerializeToElement(value); }
    }

    public required EligibilityRequestParamsProperties::Provider Provider
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("provider", out JsonElement element))
                throw new ArgumentOutOfRangeException("provider", "Missing required argument");

            return JsonSerializer.Deserialize<EligibilityRequestParamsProperties::Provider>(
                    element,
                    APIDentalPro::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("provider");
        }
        set { this.BodyProperties["provider"] = JsonSerializer.SerializeToElement(value); }
    }

    public required EligibilityRequestParamsProperties::Subscriber Subscriber
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("subscriber", out JsonElement element))
                throw new ArgumentOutOfRangeException("subscriber", "Missing required argument");

            return JsonSerializer.Deserialize<EligibilityRequestParamsProperties::Subscriber>(
                    element,
                    APIDentalPro::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("subscriber");
        }
        set { this.BodyProperties["subscriber"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string Version
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("version", out JsonElement element))
                throw new ArgumentOutOfRangeException("version", "Missing required argument");

            return JsonSerializer.Deserialize<string>(
                    element,
                    APIDentalPro::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("version");
        }
        set { this.BodyProperties["version"] = JsonSerializer.SerializeToElement(value); }
    }

    public EligibilityRequestParamsProperties::Dependent? Dependent
    {
        get
        {
            if (!this.BodyProperties.TryGetValue("dependent", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<EligibilityRequestParamsProperties::Dependent?>(
                element,
                APIDentalPro::ModelBase.SerializerOptions
            );
        }
        set { this.BodyProperties["dependent"] = JsonSerializer.SerializeToElement(value); }
    }

    public override Uri Url(APIDentalPro::IAPIDentalProClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/Eligibility")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    public StringContent BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
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
