using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using APIDentalPro = APIDentalPro;

namespace APIDentalPro.Models.Payer;

[JsonConverter(typeof(APIDentalPro::ModelConverter<PayerListResponse>))]
public sealed record class PayerListResponse
    : APIDentalPro::ModelBase,
        APIDentalPro::IFromRaw<PayerListResponse>
{
    public string? ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                APIDentalPro::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["id"] = JsonSerializer.SerializeToElement(value); }
    }

    public List<string>? AltPayerIDs
    {
        get
        {
            if (!this.Properties.TryGetValue("alt_payer_ids", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(
                element,
                APIDentalPro::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["alt_payer_ids"] = JsonSerializer.SerializeToElement(value); }
    }

    public List<string>? Features
    {
        get
        {
            if (!this.Properties.TryGetValue("features", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(
                element,
                APIDentalPro::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["features"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? Name
    {
        get
        {
            if (!this.Properties.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                APIDentalPro::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["name"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? OnederfulPayerID
    {
        get
        {
            if (!this.Properties.TryGetValue("onederfulPayerId", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                APIDentalPro::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["onederfulPayerId"] = JsonSerializer.SerializeToElement(value); }
    }

    public string? Status
    {
        get
        {
            if (!this.Properties.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(
                element,
                APIDentalPro::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["status"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ID;
        foreach (var item in this.AltPayerIDs ?? [])
        {
            _ = item;
        }
        foreach (var item in this.Features ?? [])
        {
            _ = item;
        }
        _ = this.Name;
        _ = this.OnederfulPayerID;
        _ = this.Status;
    }

    public PayerListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PayerListResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static PayerListResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
