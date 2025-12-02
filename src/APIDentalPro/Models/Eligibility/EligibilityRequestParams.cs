using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using APIDentalPro.Core;

namespace APIDentalPro.Models.Eligibility;

/// <summary>
/// Request Eligibility
/// </summary>
public sealed record class EligibilityRequestParams : ParamsBase
{
    readonly FreezableDictionary<string, JsonElement> _rawBodyData = [];
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required PayerModel Payer
    {
        get { return ModelBase.GetNotNullClass<PayerModel>(this.RawBodyData, "payer"); }
        init { ModelBase.Set(this._rawBodyData, "payer", value); }
    }

    public required Provider Provider
    {
        get { return ModelBase.GetNotNullClass<Provider>(this.RawBodyData, "provider"); }
        init { ModelBase.Set(this._rawBodyData, "provider", value); }
    }

    public required Subscriber Subscriber
    {
        get { return ModelBase.GetNotNullClass<Subscriber>(this.RawBodyData, "subscriber"); }
        init { ModelBase.Set(this._rawBodyData, "subscriber", value); }
    }

    public required string Version
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawBodyData, "version"); }
        init { ModelBase.Set(this._rawBodyData, "version", value); }
    }

    public Dependent? Dependent
    {
        get { return ModelBase.GetNullableClass<Dependent>(this.RawBodyData, "dependent"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawBodyData, "dependent", value);
        }
    }

    public EligibilityRequestParams() { }

    public EligibilityRequestParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EligibilityRequestParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = [.. rawHeaderData];
        this._rawQueryData = [.. rawQueryData];
        this._rawBodyData = [.. rawBodyData];
    }
#pragma warning restore CS8618

    public static EligibilityRequestParams FromRawUnchecked(
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

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/Eligibility")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(JsonSerializer.Serialize(this.RawBodyData), Encoding.UTF8, "application/json");
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

[JsonConverter(typeof(ModelConverter<PayerModel, PayerModelFromRaw>))]
public sealed record class PayerModel : ModelBase
{
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    public override void Validate()
    {
        _ = this.ID;
    }

    public PayerModel() { }

    public PayerModel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PayerModel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static PayerModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PayerModel(string id)
        : this()
    {
        this.ID = id;
    }
}

class PayerModelFromRaw : IFromRaw<PayerModel>
{
    public PayerModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PayerModel.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Provider, ProviderFromRaw>))]
public sealed record class Provider : ModelBase
{
    public required string Npi
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "npi"); }
        init { ModelBase.Set(this._rawData, "npi", value); }
    }

    public required string TaxID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "tax_id"); }
        init { ModelBase.Set(this._rawData, "tax_id", value); }
    }

    public override void Validate()
    {
        _ = this.Npi;
        _ = this.TaxID;
    }

    public Provider() { }

    public Provider(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Provider(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Provider FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProviderFromRaw : IFromRaw<Provider>
{
    public Provider FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Provider.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Subscriber, SubscriberFromRaw>))]
public sealed record class Subscriber : ModelBase
{
    public required
#if NET
    DateOnly
#else
    DateTimeOffset
#endif
    Dob
    {
        get { return ModelBase.GetNotNullStruct<
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            >(this.RawData, "dob"); }
        init { ModelBase.Set(this._rawData, "dob", value); }
    }

    public required string FirstName
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "first_name"); }
        init { ModelBase.Set(this._rawData, "first_name", value); }
    }

    public required string GroupNumber
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "group_number"); }
        init { ModelBase.Set(this._rawData, "group_number", value); }
    }

    public required string LastName
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "last_name"); }
        init { ModelBase.Set(this._rawData, "last_name", value); }
    }

    public required string MemberID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "member_id"); }
        init { ModelBase.Set(this._rawData, "member_id", value); }
    }

    public override void Validate()
    {
        _ = this.Dob;
        _ = this.FirstName;
        _ = this.GroupNumber;
        _ = this.LastName;
        _ = this.MemberID;
    }

    public Subscriber() { }

    public Subscriber(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Subscriber(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Subscriber FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubscriberFromRaw : IFromRaw<Subscriber>
{
    public Subscriber FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Subscriber.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ModelConverter<Dependent, DependentFromRaw>))]
public sealed record class Dependent : ModelBase
{
    public required
#if NET
    DateOnly
#else
    DateTimeOffset
#endif
    Dob
    {
        get { return ModelBase.GetNotNullStruct<
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            >(this.RawData, "dob"); }
        init { ModelBase.Set(this._rawData, "dob", value); }
    }

    public required string FirstName
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "first_name"); }
        init { ModelBase.Set(this._rawData, "first_name", value); }
    }

    public required string GroupNumber
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "group_number"); }
        init { ModelBase.Set(this._rawData, "group_number", value); }
    }

    public required string LastName
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "last_name"); }
        init { ModelBase.Set(this._rawData, "last_name", value); }
    }

    public required string MemberID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "member_id"); }
        init { ModelBase.Set(this._rawData, "member_id", value); }
    }

    public override void Validate()
    {
        _ = this.Dob;
        _ = this.FirstName;
        _ = this.GroupNumber;
        _ = this.LastName;
        _ = this.MemberID;
    }

    public Dependent() { }

    public Dependent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Dependent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static Dependent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DependentFromRaw : IFromRaw<Dependent>
{
    public Dependent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Dependent.FromRawUnchecked(rawData);
}
