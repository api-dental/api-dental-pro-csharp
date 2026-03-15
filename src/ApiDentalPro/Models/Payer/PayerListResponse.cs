using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using ApiDentalPro.Core;
using ApiDentalPro.Exceptions;

namespace ApiDentalPro.Models.Payer;

[JsonConverter(typeof(JsonModelConverter<PayerListResponse, PayerListResponseFromRaw>))]
public sealed record class PayerListResponse : JsonModel
{
    public Data? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Data>("data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data?.Validate();
    }

    public PayerListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PayerListResponse(PayerListResponse payerListResponse)
        : base(payerListResponse) { }
#pragma warning restore CS8618

    public PayerListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PayerListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PayerListResponseFromRaw.FromRawUnchecked"/>
    public static PayerListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PayerListResponseFromRaw : IFromRawJson<PayerListResponse>
{
    /// <inheritdoc/>
    public PayerListResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PayerListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    public IReadOnlyList<ApidentalPayerList>? ApidentalPayerList
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApidentalPayerList>>(
                "apidental_payer_list"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ApidentalPayerList>?>(
                "apidental_payer_list",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.ApidentalPayerList ?? [])
        {
            item.Validate();
        }
    }

    public Data() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data(Data data)
        : base(data) { }
#pragma warning restore CS8618

    public Data(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Data(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Data.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ApidentalPayerList, ApidentalPayerListFromRaw>))]
public sealed record class ApidentalPayerList : JsonModel
{
    /// <summary>
    /// Unique payer identifier
    /// </summary>
    public string? ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// Alternate payer identifiers
    /// </summary>
    public IReadOnlyList<string>? AltPayerIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("alt_payer_ids");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "alt_payer_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Supported features (e.g., eligibility, claims)
    /// </summary>
    public IReadOnlyList<string>? Features
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("features");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "features",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Payer display name
    /// </summary>
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// Internal payer mapping ID
    /// </summary>
    public string? OnederfulPayerID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("onederfulPayerId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("onederfulPayerId", value);
        }
    }

    /// <summary>
    /// Payer availability status
    /// </summary>
    public ApiEnum<string, Status>? Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Status>>("status");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AltPayerIds;
        _ = this.Features;
        _ = this.Name;
        _ = this.OnederfulPayerID;
        this.Status?.Validate();
    }

    public ApidentalPayerList() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApidentalPayerList(ApidentalPayerList apidentalPayerList)
        : base(apidentalPayerList) { }
#pragma warning restore CS8618

    public ApidentalPayerList(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApidentalPayerList(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApidentalPayerListFromRaw.FromRawUnchecked"/>
    public static ApidentalPayerList FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ApidentalPayerListFromRaw : IFromRawJson<ApidentalPayerList>
{
    /// <inheritdoc/>
    public ApidentalPayerList FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ApidentalPayerList.FromRawUnchecked(rawData);
}

/// <summary>
/// Payer availability status
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Active,
    Inactive,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => Status.Active,
            "inactive" => Status.Inactive,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Active => "active",
                Status.Inactive => "inactive",
                _ => throw new ApiDentalProInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
