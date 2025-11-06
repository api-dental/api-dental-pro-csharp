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
    readonly FreezableDictionary<string, JsonElement> _bodyProperties = [];
    public IReadOnlyDictionary<string, JsonElement> BodyProperties
    {
        get { return this._bodyProperties.Freeze(); }
    }

    public required PayerModel Payer
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("payer", out JsonElement element))
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
            this._bodyProperties["payer"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required Provider Provider
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("provider", out JsonElement element))
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
            this._bodyProperties["provider"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required Subscriber Subscriber
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("subscriber", out JsonElement element))
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
            this._bodyProperties["subscriber"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string Version
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("version", out JsonElement element))
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
            this._bodyProperties["version"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Dependent? Dependent
    {
        get
        {
            if (!this._bodyProperties.TryGetValue("dependent", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dependent?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._bodyProperties["dependent"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public EligibilityRequestParams() { }

    public EligibilityRequestParams(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EligibilityRequestParams(
        FrozenDictionary<string, JsonElement> headerProperties,
        FrozenDictionary<string, JsonElement> queryProperties,
        FrozenDictionary<string, JsonElement> bodyProperties
    )
    {
        this._headerProperties = [.. headerProperties];
        this._queryProperties = [.. queryProperties];
        this._bodyProperties = [.. bodyProperties];
    }
#pragma warning restore CS8618

    public static EligibilityRequestParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> headerProperties,
        IReadOnlyDictionary<string, JsonElement> queryProperties,
        IReadOnlyDictionary<string, JsonElement> bodyProperties
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(headerProperties),
            FrozenDictionary.ToFrozenDictionary(queryProperties),
            FrozenDictionary.ToFrozenDictionary(bodyProperties)
        );
    }

    public override Uri Url(IAPIDentalProClient client)
    {
        return new UriBuilder(client.BaseUrl.ToString().TrimEnd('/') + "/Eligibility")
        {
            Query = this.QueryString(client),
        }.Uri;
    }

    internal override StringContent? BodyContent()
    {
        return new(
            JsonSerializer.Serialize(this.BodyProperties),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request,
        IAPIDentalProClient client
    )
    {
        ParamsBase.AddDefaultHeaders(request, client);
        foreach (var item in this.HeaderProperties)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }
}

[JsonConverter(typeof(ModelConverter<PayerModel>))]
public sealed record class PayerModel : ModelBase, IFromRaw<PayerModel>
{
    public required string ID
    {
        get
        {
            if (!this._properties.TryGetValue("id", out JsonElement element))
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
            this._properties["id"] = JsonSerializer.SerializeToElement(
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

    public PayerModel(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PayerModel(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static PayerModel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public PayerModel(string id)
        : this()
    {
        this.ID = id;
    }
}

[JsonConverter(typeof(ModelConverter<Provider>))]
public sealed record class Provider : ModelBase, IFromRaw<Provider>
{
    public required string Npi
    {
        get
        {
            if (!this._properties.TryGetValue("npi", out JsonElement element))
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
            this._properties["npi"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string TaxID
    {
        get
        {
            if (!this._properties.TryGetValue("tax_id", out JsonElement element))
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
            this._properties["tax_id"] = JsonSerializer.SerializeToElement(
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

    public Provider(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Provider(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Provider FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(ModelConverter<Subscriber>))]
public sealed record class Subscriber : ModelBase, IFromRaw<Subscriber>
{
    public required DateOnly Dob
    {
        get
        {
            if (!this._properties.TryGetValue("dob", out JsonElement element))
                throw new APIDentalProInvalidDataException(
                    "'dob' cannot be null",
                    new ArgumentOutOfRangeException("dob", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateOnly>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["dob"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string FirstName
    {
        get
        {
            if (!this._properties.TryGetValue("first_name", out JsonElement element))
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
            this._properties["first_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string GroupNumber
    {
        get
        {
            if (!this._properties.TryGetValue("group_number", out JsonElement element))
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
            this._properties["group_number"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string LastName
    {
        get
        {
            if (!this._properties.TryGetValue("last_name", out JsonElement element))
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
            this._properties["last_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string MemberID
    {
        get
        {
            if (!this._properties.TryGetValue("member_id", out JsonElement element))
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
            this._properties["member_id"] = JsonSerializer.SerializeToElement(
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

    public Subscriber(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Subscriber(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Subscriber FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(ModelConverter<Dependent>))]
public sealed record class Dependent : ModelBase, IFromRaw<Dependent>
{
    public required DateOnly Dob
    {
        get
        {
            if (!this._properties.TryGetValue("dob", out JsonElement element))
                throw new APIDentalProInvalidDataException(
                    "'dob' cannot be null",
                    new ArgumentOutOfRangeException("dob", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateOnly>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["dob"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string FirstName
    {
        get
        {
            if (!this._properties.TryGetValue("first_name", out JsonElement element))
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
            this._properties["first_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string GroupNumber
    {
        get
        {
            if (!this._properties.TryGetValue("group_number", out JsonElement element))
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
            this._properties["group_number"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string LastName
    {
        get
        {
            if (!this._properties.TryGetValue("last_name", out JsonElement element))
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
            this._properties["last_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string MemberID
    {
        get
        {
            if (!this._properties.TryGetValue("member_id", out JsonElement element))
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
            this._properties["member_id"] = JsonSerializer.SerializeToElement(
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

    public Dependent(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Dependent(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Dependent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
