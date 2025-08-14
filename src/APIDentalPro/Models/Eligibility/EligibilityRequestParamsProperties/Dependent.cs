using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using APIDentalPro = APIDentalPro;

namespace APIDentalPro.Models.Eligibility.EligibilityRequestParamsProperties;

[JsonConverter(typeof(APIDentalPro::ModelConverter<Dependent>))]
public sealed record class Dependent : APIDentalPro::ModelBase, APIDentalPro::IFromRaw<Dependent>
{
    public required DateOnly Dob
    {
        get
        {
            if (!this.Properties.TryGetValue("dob", out JsonElement element))
                throw new ArgumentOutOfRangeException("dob", "Missing required argument");

            return JsonSerializer.Deserialize<DateOnly>(
                element,
                APIDentalPro::ModelBase.SerializerOptions
            );
        }
        set { this.Properties["dob"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string FirstName
    {
        get
        {
            if (!this.Properties.TryGetValue("first_name", out JsonElement element))
                throw new ArgumentOutOfRangeException("first_name", "Missing required argument");

            return JsonSerializer.Deserialize<string>(
                    element,
                    APIDentalPro::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("first_name");
        }
        set { this.Properties["first_name"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string GroupNumber
    {
        get
        {
            if (!this.Properties.TryGetValue("group_number", out JsonElement element))
                throw new ArgumentOutOfRangeException("group_number", "Missing required argument");

            return JsonSerializer.Deserialize<string>(
                    element,
                    APIDentalPro::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("group_number");
        }
        set { this.Properties["group_number"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string LastName
    {
        get
        {
            if (!this.Properties.TryGetValue("last_name", out JsonElement element))
                throw new ArgumentOutOfRangeException("last_name", "Missing required argument");

            return JsonSerializer.Deserialize<string>(
                    element,
                    APIDentalPro::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("last_name");
        }
        set { this.Properties["last_name"] = JsonSerializer.SerializeToElement(value); }
    }

    public required string MemberID
    {
        get
        {
            if (!this.Properties.TryGetValue("member_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("member_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(
                    element,
                    APIDentalPro::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("member_id");
        }
        set { this.Properties["member_id"] = JsonSerializer.SerializeToElement(value); }
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Dependent(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Dependent FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
