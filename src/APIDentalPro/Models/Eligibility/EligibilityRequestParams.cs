using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using APIDentalPro.Core;
using APIDentalPro.Exceptions;

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
        get
        {
            if (!this._rawBodyData.TryGetValue("payer", out JsonElement element))
                throw new APIDentalProInvalidDataException(
                    "'payer' cannot be null",
                    new ArgumentOutOfRangeException("payer", "Missing required argument")
                );

            return JsonSerializer.Deserialize<PayerModel>(element, ModelBase.SerializerOptions)
                ?? throw new APIDentalProInvalidDataException(
                    "'payer' cannot be null",
                    new ArgumentNullException("payer")
                );
        }
        init
        {
            this._rawBodyData["payer"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required Provider Provider
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("provider", out JsonElement element))
                throw new APIDentalProInvalidDataException(
                    "'provider' cannot be null",
                    new ArgumentOutOfRangeException("provider", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Provider>(element, ModelBase.SerializerOptions)
                ?? throw new APIDentalProInvalidDataException(
                    "'provider' cannot be null",
                    new ArgumentNullException("provider")
                );
        }
        init
        {
            this._rawBodyData["provider"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required Subscriber Subscriber
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("subscriber", out JsonElement element))
                throw new APIDentalProInvalidDataException(
                    "'subscriber' cannot be null",
                    new ArgumentOutOfRangeException("subscriber", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Subscriber>(element, ModelBase.SerializerOptions)
                ?? throw new APIDentalProInvalidDataException(
                    "'subscriber' cannot be null",
                    new ArgumentNullException("subscriber")
                );
        }
        init
        {
            this._rawBodyData["subscriber"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Version
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("version", out JsonElement element))
                throw new APIDentalProInvalidDataException(
                    "'version' cannot be null",
                    new ArgumentOutOfRangeException("version", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new APIDentalProInvalidDataException(
                    "'version' cannot be null",
                    new ArgumentNullException("version")
                );
        }
        init
        {
            this._rawBodyData["version"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Dependent? Dependent
    {
        get
        {
            if (!this._rawBodyData.TryGetValue("dependent", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dependent?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData["dependent"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
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
        get
        {
            if (!this._rawData.TryGetValue("id", out JsonElement element))
                throw new APIDentalProInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new APIDentalProInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentNullException("id")
                );
        }
        init
        {
            this._rawData["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
        get
        {
            if (!this._rawData.TryGetValue("npi", out JsonElement element))
                throw new APIDentalProInvalidDataException(
                    "'npi' cannot be null",
                    new ArgumentOutOfRangeException("npi", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new APIDentalProInvalidDataException(
                    "'npi' cannot be null",
                    new ArgumentNullException("npi")
                );
        }
        init
        {
            this._rawData["npi"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string TaxID
    {
        get
        {
            if (!this._rawData.TryGetValue("tax_id", out JsonElement element))
                throw new APIDentalProInvalidDataException(
                    "'tax_id' cannot be null",
                    new ArgumentOutOfRangeException("tax_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new APIDentalProInvalidDataException(
                    "'tax_id' cannot be null",
                    new ArgumentNullException("tax_id")
                );
        }
        init
        {
            this._rawData["tax_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
        get
        {
            if (!this._rawData.TryGetValue("dob", out JsonElement element))
                throw new APIDentalProInvalidDataException(
                    "'dob' cannot be null",
                    new ArgumentOutOfRangeException("dob", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["dob"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string FirstName
    {
        get
        {
            if (!this._rawData.TryGetValue("first_name", out JsonElement element))
                throw new APIDentalProInvalidDataException(
                    "'first_name' cannot be null",
                    new ArgumentOutOfRangeException("first_name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new APIDentalProInvalidDataException(
                    "'first_name' cannot be null",
                    new ArgumentNullException("first_name")
                );
        }
        init
        {
            this._rawData["first_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string GroupNumber
    {
        get
        {
            if (!this._rawData.TryGetValue("group_number", out JsonElement element))
                throw new APIDentalProInvalidDataException(
                    "'group_number' cannot be null",
                    new ArgumentOutOfRangeException("group_number", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new APIDentalProInvalidDataException(
                    "'group_number' cannot be null",
                    new ArgumentNullException("group_number")
                );
        }
        init
        {
            this._rawData["group_number"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string LastName
    {
        get
        {
            if (!this._rawData.TryGetValue("last_name", out JsonElement element))
                throw new APIDentalProInvalidDataException(
                    "'last_name' cannot be null",
                    new ArgumentOutOfRangeException("last_name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new APIDentalProInvalidDataException(
                    "'last_name' cannot be null",
                    new ArgumentNullException("last_name")
                );
        }
        init
        {
            this._rawData["last_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string MemberID
    {
        get
        {
            if (!this._rawData.TryGetValue("member_id", out JsonElement element))
                throw new APIDentalProInvalidDataException(
                    "'member_id' cannot be null",
                    new ArgumentOutOfRangeException("member_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new APIDentalProInvalidDataException(
                    "'member_id' cannot be null",
                    new ArgumentNullException("member_id")
                );
        }
        init
        {
            this._rawData["member_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
        get
        {
            if (!this._rawData.TryGetValue("dob", out JsonElement element))
                throw new APIDentalProInvalidDataException(
                    "'dob' cannot be null",
                    new ArgumentOutOfRangeException("dob", "Missing required argument")
                );

            return JsonSerializer.Deserialize<
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            >(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["dob"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string FirstName
    {
        get
        {
            if (!this._rawData.TryGetValue("first_name", out JsonElement element))
                throw new APIDentalProInvalidDataException(
                    "'first_name' cannot be null",
                    new ArgumentOutOfRangeException("first_name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new APIDentalProInvalidDataException(
                    "'first_name' cannot be null",
                    new ArgumentNullException("first_name")
                );
        }
        init
        {
            this._rawData["first_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string GroupNumber
    {
        get
        {
            if (!this._rawData.TryGetValue("group_number", out JsonElement element))
                throw new APIDentalProInvalidDataException(
                    "'group_number' cannot be null",
                    new ArgumentOutOfRangeException("group_number", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new APIDentalProInvalidDataException(
                    "'group_number' cannot be null",
                    new ArgumentNullException("group_number")
                );
        }
        init
        {
            this._rawData["group_number"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string LastName
    {
        get
        {
            if (!this._rawData.TryGetValue("last_name", out JsonElement element))
                throw new APIDentalProInvalidDataException(
                    "'last_name' cannot be null",
                    new ArgumentOutOfRangeException("last_name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new APIDentalProInvalidDataException(
                    "'last_name' cannot be null",
                    new ArgumentNullException("last_name")
                );
        }
        init
        {
            this._rawData["last_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string MemberID
    {
        get
        {
            if (!this._rawData.TryGetValue("member_id", out JsonElement element))
                throw new APIDentalProInvalidDataException(
                    "'member_id' cannot be null",
                    new ArgumentOutOfRangeException("member_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new APIDentalProInvalidDataException(
                    "'member_id' cannot be null",
                    new ArgumentNullException("member_id")
                );
        }
        init
        {
            this._rawData["member_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
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
