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
        get { return ModelBase.GetNullableClass<string>(this.RawData, "id"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "id", value);
        }
    }

    public IReadOnlyList<string>? AltPayerIDs
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawData, "alt_payer_ids"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "alt_payer_ids", value);
        }
    }

    public IReadOnlyList<string>? Features
    {
        get { return ModelBase.GetNullableClass<List<string>>(this.RawData, "features"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "features", value);
        }
    }

    public string? Name
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "name"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "name", value);
        }
    }

    public string? OnederfulPayerID
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "onederfulPayerId"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "onederfulPayerId", value);
        }
    }

    public string? Status
    {
        get { return ModelBase.GetNullableClass<string>(this.RawData, "status"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "status", value);
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
