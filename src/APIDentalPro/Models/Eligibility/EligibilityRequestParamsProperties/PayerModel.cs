using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using APIDentalPro.Core;
using APIDentalPro.Exceptions;

namespace APIDentalPro.Models.Eligibility.EligibilityRequestParamsProperties;

[JsonConverter(typeof(ModelConverter<PayerModel>))]
public sealed record class PayerModel : ModelBase, IFromRaw<PayerModel>
{
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out JsonElement element))
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
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PayerModel(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static PayerModel FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public PayerModel(string id)
        : this()
    {
        this.ID = id;
    }
}
