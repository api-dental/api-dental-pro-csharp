using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using APIDentalPro = APIDentalPro;

namespace APIDentalPro.Models.Eligibility.EligibilityRequestParamsProperties;

[JsonConverter(typeof(APIDentalPro::ModelConverter<Payer>))]
public sealed record class Payer : APIDentalPro::ModelBase, APIDentalPro::IFromRaw<Payer>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new ArgumentOutOfRangeException("id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(
                    element,
                    APIDentalPro::ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("id");
        }
        set { this.Properties["id"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ID;
    }

    public Payer() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Payer(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Payer FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public Payer(string id)
        : this()
    {
        this.ID = id;
    }
}
