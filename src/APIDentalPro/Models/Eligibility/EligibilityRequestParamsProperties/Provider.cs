using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace APIDentalPro.Models.Eligibility.EligibilityRequestParamsProperties;

[JsonConverter(typeof(ModelConverter<Provider>))]
public sealed record class Provider : ModelBase, IFromRaw<Provider>
{
    public required string Npi
    {
        get
        {
            if (!this.Properties.TryGetValue("npi", out JsonElement element))
                throw new ArgumentOutOfRangeException("npi", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("npi");
        }
        set
        {
            this.Properties["npi"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string TaxID
    {
        get
        {
            if (!this.Properties.TryGetValue("tax_id", out JsonElement element))
                throw new ArgumentOutOfRangeException("tax_id", "Missing required argument");

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("tax_id");
        }
        set
        {
            this.Properties["tax_id"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Provider(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Provider FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
