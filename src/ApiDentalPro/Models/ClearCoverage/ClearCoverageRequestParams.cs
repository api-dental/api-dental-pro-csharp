using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using ApiDentalPro.Core;
using ApiDentalPro.Exceptions;

namespace ApiDentalPro.Models.ClearCoverage;

/// <summary>
/// Submit an enhanced eligibility and benefits verification request via Vyne ClearCoverage.
/// Returns enriched, standardized, and normalized data relevant for dental use cases
/// with deep benefit insights across supported payers.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ClearCoverageRequestParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required ClearCoverageRequestParamsPayer Payer
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ClearCoverageRequestParamsPayer>("payer");
        }
        init { this._rawBodyData.Set("payer", value); }
    }

    public required Provider Provider
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<Provider>("provider");
        }
        init { this._rawBodyData.Set("provider", value); }
    }

    public required Subscriber Subscriber
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<Subscriber>("subscriber");
        }
        init { this._rawBodyData.Set("subscriber", value); }
    }

    /// <summary>
    /// API version. Use "v2" for the current version. Version "v1" is deprecated
    /// and returns a legacy response format.
    /// </summary>
    public required ApiEnum<string, global::ApiDentalPro.Models.ClearCoverage.Version> Version
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<
                ApiEnum<string, global::ApiDentalPro.Models.ClearCoverage.Version>
            >("version");
        }
        init { this._rawBodyData.Set("version", value); }
    }

    /// <summary>
    /// Optional dependent information
    /// </summary>
    public Dependent? Dependent
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<Dependent>("dependent");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("dependent", value);
        }
    }

    /// <summary>
    /// Optional location identifier
    /// </summary>
    public string? LocationID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("location_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("location_id", value);
        }
    }

    public ClearCoverageRequestParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ClearCoverageRequestParams(ClearCoverageRequestParams clearCoverageRequestParams)
        : base(clearCoverageRequestParams)
    {
        this._rawBodyData = new(clearCoverageRequestParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ClearCoverageRequestParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ClearCoverageRequestParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ClearCoverageRequestParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ClearCoverageRequestParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/ClearCoverage")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

[JsonConverter(
    typeof(JsonModelConverter<
        ClearCoverageRequestParamsPayer,
        ClearCoverageRequestParamsPayerFromRaw
    >)
)]
public sealed record class ClearCoverageRequestParamsPayer : JsonModel
{
    /// <summary>
    /// ClearCoverage payer ID (see supported carriers list)
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
    }

    public ClearCoverageRequestParamsPayer() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ClearCoverageRequestParamsPayer(
        ClearCoverageRequestParamsPayer clearCoverageRequestParamsPayer
    )
        : base(clearCoverageRequestParamsPayer) { }
#pragma warning restore CS8618

    public ClearCoverageRequestParamsPayer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ClearCoverageRequestParamsPayer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ClearCoverageRequestParamsPayerFromRaw.FromRawUnchecked"/>
    public static ClearCoverageRequestParamsPayer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ClearCoverageRequestParamsPayer(string id)
        : this()
    {
        this.ID = id;
    }
}

class ClearCoverageRequestParamsPayerFromRaw : IFromRawJson<ClearCoverageRequestParamsPayer>
{
    /// <inheritdoc/>
    public ClearCoverageRequestParamsPayer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ClearCoverageRequestParamsPayer.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Provider, ProviderFromRaw>))]
public sealed record class Provider : JsonModel
{
    /// <summary>
    /// Provider's National Provider Identifier (10 digits)
    /// </summary>
    public required string Npi
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("npi");
        }
        init { this._rawData.Set("npi", value); }
    }

    /// <summary>
    /// Provider's Tax Identification Number (9 digits)
    /// </summary>
    public required string TaxID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tax_id");
        }
        init { this._rawData.Set("tax_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Npi;
        _ = this.TaxID;
    }

    public Provider() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Provider(Provider provider)
        : base(provider) { }
#pragma warning restore CS8618

    public Provider(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Provider(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProviderFromRaw.FromRawUnchecked"/>
    public static Provider FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProviderFromRaw : IFromRawJson<Provider>
{
    /// <inheritdoc/>
    public Provider FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Provider.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Subscriber, SubscriberFromRaw>))]
public sealed record class Subscriber : JsonModel
{
    /// <summary>
    /// MM/DD/YYYY format
    /// </summary>
    public required string Dob
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("dob");
        }
        init { this._rawData.Set("dob", value); }
    }

    public required string FirstName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("first_name");
        }
        init { this._rawData.Set("first_name", value); }
    }

    public required string GroupNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("group_number");
        }
        init { this._rawData.Set("group_number", value); }
    }

    public required string LastName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("last_name");
        }
        init { this._rawData.Set("last_name", value); }
    }

    public required string MemberID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("member_id");
        }
        init { this._rawData.Set("member_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Dob;
        _ = this.FirstName;
        _ = this.GroupNumber;
        _ = this.LastName;
        _ = this.MemberID;
    }

    public Subscriber() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Subscriber(Subscriber subscriber)
        : base(subscriber) { }
#pragma warning restore CS8618

    public Subscriber(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Subscriber(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubscriberFromRaw.FromRawUnchecked"/>
    public static Subscriber FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriberFromRaw : IFromRawJson<Subscriber>
{
    /// <inheritdoc/>
    public Subscriber FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Subscriber.FromRawUnchecked(rawData);
}

/// <summary>
/// API version. Use "v2" for the current version. Version "v1" is deprecated and
/// returns a legacy response format.
/// </summary>
[JsonConverter(typeof(VersionConverter))]
public enum Version
{
    V1,
    V2,
}

sealed class VersionConverter : JsonConverter<global::ApiDentalPro.Models.ClearCoverage.Version>
{
    public override global::ApiDentalPro.Models.ClearCoverage.Version Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "v1" => global::ApiDentalPro.Models.ClearCoverage.Version.V1,
            "v2" => global::ApiDentalPro.Models.ClearCoverage.Version.V2,
            _ => (global::ApiDentalPro.Models.ClearCoverage.Version)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::ApiDentalPro.Models.ClearCoverage.Version value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::ApiDentalPro.Models.ClearCoverage.Version.V1 => "v1",
                global::ApiDentalPro.Models.ClearCoverage.Version.V2 => "v2",
                _ => throw new ApiDentalProInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Optional dependent information
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Dependent, DependentFromRaw>))]
public sealed record class Dependent : JsonModel
{
    public string? Dob
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("dob");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("dob", value);
        }
    }

    public string? FirstName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("first_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("first_name", value);
        }
    }

    public string? GroupNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("group_number");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("group_number", value);
        }
    }

    public string? LastName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("last_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("last_name", value);
        }
    }

    public string? MemberID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("member_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("member_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Dob;
        _ = this.FirstName;
        _ = this.GroupNumber;
        _ = this.LastName;
        _ = this.MemberID;
    }

    public Dependent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Dependent(Dependent dependent)
        : base(dependent) { }
#pragma warning restore CS8618

    public Dependent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Dependent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DependentFromRaw.FromRawUnchecked"/>
    public static Dependent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DependentFromRaw : IFromRawJson<Dependent>
{
    /// <inheritdoc/>
    public Dependent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Dependent.FromRawUnchecked(rawData);
}
