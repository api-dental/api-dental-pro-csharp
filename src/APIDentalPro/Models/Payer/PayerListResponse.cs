using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using APIDentalPro.Core;

namespace APIDentalPro.Models.Payer;

[JsonConverter(typeof(ModelConverter<PayerListResponse, PayerListResponseFromRaw>))]
public sealed record class PayerListResponse : ModelBase
{
    public string? ID
    {
        get
        {
            if (!this._rawData.TryGetValue("id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public IReadOnlyList<string>? AltPayerIDs
    {
        get
        {
            if (!this._rawData.TryGetValue("alt_payer_ids", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["alt_payer_ids"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public IReadOnlyList<string>? Features
    {
        get
        {
            if (!this._rawData.TryGetValue("features", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<string>?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["features"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Name
    {
        get
        {
            if (!this._rawData.TryGetValue("name", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? OnederfulPayerID
    {
        get
        {
            if (!this._rawData.TryGetValue("onederfulPayerId", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["onederfulPayerId"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Status
    {
        get
        {
            if (!this._rawData.TryGetValue("status", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["status"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.AltPayerIDs;
        _ = this.Features;
        _ = this.Name;
        _ = this.OnederfulPayerID;
        _ = this.Status;
    }

    public PayerListResponse() { }

    public PayerListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PayerListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PayerListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PayerListResponseFromRaw : IFromRaw<PayerListResponse>
{
    public PayerListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PayerListResponse.FromRawUnchecked(rawData);
}
