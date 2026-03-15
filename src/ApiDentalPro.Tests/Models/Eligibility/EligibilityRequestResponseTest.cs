using System.Collections.Generic;
using System.Text.Json;
using ApiDentalPro.Core;
using ApiDentalPro.Models.Eligibility;

namespace ApiDentalPro.Tests.Models.Eligibility;

public class EligibilityRequestResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EligibilityRequestResponse
        {
            Data = new()
            {
                ApidentalPostEligibility = new()
                {
                    ActiveCoverage = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    Coinsurance = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    Deductible = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    Limitations = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    Maximums = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    NotCovered = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    Patient = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Payer = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Plan = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Provider = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Subscriber = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            },
        };

        Data expectedData = new()
        {
            ApidentalPostEligibility = new()
            {
                ActiveCoverage = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Coinsurance = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Deductible = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Limitations = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Maximums = [JsonSerializer.Deserialize<JsonElement>("{}")],
                NotCovered = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Patient = JsonSerializer.Deserialize<JsonElement>("{}"),
                Payer = JsonSerializer.Deserialize<JsonElement>("{}"),
                Plan = JsonSerializer.Deserialize<JsonElement>("{}"),
                Provider = JsonSerializer.Deserialize<JsonElement>("{}"),
                Subscriber = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EligibilityRequestResponse
        {
            Data = new()
            {
                ApidentalPostEligibility = new()
                {
                    ActiveCoverage = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    Coinsurance = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    Deductible = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    Limitations = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    Maximums = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    NotCovered = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    Patient = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Payer = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Plan = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Provider = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Subscriber = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EligibilityRequestResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EligibilityRequestResponse
        {
            Data = new()
            {
                ApidentalPostEligibility = new()
                {
                    ActiveCoverage = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    Coinsurance = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    Deductible = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    Limitations = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    Maximums = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    NotCovered = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    Patient = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Payer = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Plan = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Provider = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Subscriber = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EligibilityRequestResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Data expectedData = new()
        {
            ApidentalPostEligibility = new()
            {
                ActiveCoverage = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Coinsurance = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Deductible = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Limitations = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Maximums = [JsonSerializer.Deserialize<JsonElement>("{}")],
                NotCovered = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Patient = JsonSerializer.Deserialize<JsonElement>("{}"),
                Payer = JsonSerializer.Deserialize<JsonElement>("{}"),
                Plan = JsonSerializer.Deserialize<JsonElement>("{}"),
                Provider = JsonSerializer.Deserialize<JsonElement>("{}"),
                Subscriber = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EligibilityRequestResponse
        {
            Data = new()
            {
                ApidentalPostEligibility = new()
                {
                    ActiveCoverage = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    Coinsurance = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    Deductible = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    Limitations = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    Maximums = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    NotCovered = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    Patient = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Payer = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Plan = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Provider = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Subscriber = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EligibilityRequestResponse { };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EligibilityRequestResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EligibilityRequestResponse
        {
            // Null should be interpreted as omitted for these properties
            Data = null,
        };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EligibilityRequestResponse
        {
            // Null should be interpreted as omitted for these properties
            Data = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EligibilityRequestResponse
        {
            Data = new()
            {
                ApidentalPostEligibility = new()
                {
                    ActiveCoverage = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    Coinsurance = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    Deductible = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    Limitations = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    Maximums = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    NotCovered = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    Patient = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Payer = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Plan = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Provider = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Subscriber = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            },
        };

        EligibilityRequestResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data
        {
            ApidentalPostEligibility = new()
            {
                ActiveCoverage = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Coinsurance = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Deductible = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Limitations = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Maximums = [JsonSerializer.Deserialize<JsonElement>("{}")],
                NotCovered = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Patient = JsonSerializer.Deserialize<JsonElement>("{}"),
                Payer = JsonSerializer.Deserialize<JsonElement>("{}"),
                Plan = JsonSerializer.Deserialize<JsonElement>("{}"),
                Provider = JsonSerializer.Deserialize<JsonElement>("{}"),
                Subscriber = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
        };

        ApidentalPostEligibility expectedApidentalPostEligibility = new()
        {
            ActiveCoverage = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Coinsurance = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Deductible = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Limitations = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Maximums = [JsonSerializer.Deserialize<JsonElement>("{}")],
            NotCovered = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Patient = JsonSerializer.Deserialize<JsonElement>("{}"),
            Payer = JsonSerializer.Deserialize<JsonElement>("{}"),
            Plan = JsonSerializer.Deserialize<JsonElement>("{}"),
            Provider = JsonSerializer.Deserialize<JsonElement>("{}"),
            Subscriber = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        Assert.Equal(expectedApidentalPostEligibility, model.ApidentalPostEligibility);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
        {
            ApidentalPostEligibility = new()
            {
                ActiveCoverage = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Coinsurance = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Deductible = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Limitations = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Maximums = [JsonSerializer.Deserialize<JsonElement>("{}")],
                NotCovered = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Patient = JsonSerializer.Deserialize<JsonElement>("{}"),
                Payer = JsonSerializer.Deserialize<JsonElement>("{}"),
                Plan = JsonSerializer.Deserialize<JsonElement>("{}"),
                Provider = JsonSerializer.Deserialize<JsonElement>("{}"),
                Subscriber = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Data
        {
            ApidentalPostEligibility = new()
            {
                ActiveCoverage = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Coinsurance = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Deductible = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Limitations = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Maximums = [JsonSerializer.Deserialize<JsonElement>("{}")],
                NotCovered = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Patient = JsonSerializer.Deserialize<JsonElement>("{}"),
                Payer = JsonSerializer.Deserialize<JsonElement>("{}"),
                Plan = JsonSerializer.Deserialize<JsonElement>("{}"),
                Provider = JsonSerializer.Deserialize<JsonElement>("{}"),
                Subscriber = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        ApidentalPostEligibility expectedApidentalPostEligibility = new()
        {
            ActiveCoverage = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Coinsurance = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Deductible = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Limitations = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Maximums = [JsonSerializer.Deserialize<JsonElement>("{}")],
            NotCovered = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Patient = JsonSerializer.Deserialize<JsonElement>("{}"),
            Payer = JsonSerializer.Deserialize<JsonElement>("{}"),
            Plan = JsonSerializer.Deserialize<JsonElement>("{}"),
            Provider = JsonSerializer.Deserialize<JsonElement>("{}"),
            Subscriber = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        Assert.Equal(expectedApidentalPostEligibility, deserialized.ApidentalPostEligibility);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
        {
            ApidentalPostEligibility = new()
            {
                ActiveCoverage = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Coinsurance = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Deductible = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Limitations = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Maximums = [JsonSerializer.Deserialize<JsonElement>("{}")],
                NotCovered = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Patient = JsonSerializer.Deserialize<JsonElement>("{}"),
                Payer = JsonSerializer.Deserialize<JsonElement>("{}"),
                Plan = JsonSerializer.Deserialize<JsonElement>("{}"),
                Provider = JsonSerializer.Deserialize<JsonElement>("{}"),
                Subscriber = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Data { };

        Assert.Null(model.ApidentalPostEligibility);
        Assert.False(model.RawData.ContainsKey("apidental_post_eligibility"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Data { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Data
        {
            // Null should be interpreted as omitted for these properties
            ApidentalPostEligibility = null,
        };

        Assert.Null(model.ApidentalPostEligibility);
        Assert.False(model.RawData.ContainsKey("apidental_post_eligibility"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Data
        {
            // Null should be interpreted as omitted for these properties
            ApidentalPostEligibility = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data
        {
            ApidentalPostEligibility = new()
            {
                ActiveCoverage = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Coinsurance = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Deductible = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Limitations = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Maximums = [JsonSerializer.Deserialize<JsonElement>("{}")],
                NotCovered = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Patient = JsonSerializer.Deserialize<JsonElement>("{}"),
                Payer = JsonSerializer.Deserialize<JsonElement>("{}"),
                Plan = JsonSerializer.Deserialize<JsonElement>("{}"),
                Provider = JsonSerializer.Deserialize<JsonElement>("{}"),
                Subscriber = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ApidentalPostEligibilityTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ApidentalPostEligibility
        {
            ActiveCoverage = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Coinsurance = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Deductible = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Limitations = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Maximums = [JsonSerializer.Deserialize<JsonElement>("{}")],
            NotCovered = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Patient = JsonSerializer.Deserialize<JsonElement>("{}"),
            Payer = JsonSerializer.Deserialize<JsonElement>("{}"),
            Plan = JsonSerializer.Deserialize<JsonElement>("{}"),
            Provider = JsonSerializer.Deserialize<JsonElement>("{}"),
            Subscriber = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        List<JsonElement> expectedActiveCoverage = [JsonSerializer.Deserialize<JsonElement>("{}")];
        List<JsonElement> expectedCoinsurance = [JsonSerializer.Deserialize<JsonElement>("{}")];
        List<JsonElement> expectedDeductible = [JsonSerializer.Deserialize<JsonElement>("{}")];
        List<JsonElement> expectedLimitations = [JsonSerializer.Deserialize<JsonElement>("{}")];
        List<JsonElement> expectedMaximums = [JsonSerializer.Deserialize<JsonElement>("{}")];
        List<JsonElement> expectedNotCovered = [JsonSerializer.Deserialize<JsonElement>("{}")];
        JsonElement expectedPatient = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedPayer = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedPlan = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedProvider = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedSubscriber = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.NotNull(model.ActiveCoverage);
        Assert.Equal(expectedActiveCoverage.Count, model.ActiveCoverage.Count);
        for (int i = 0; i < expectedActiveCoverage.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedActiveCoverage[i], model.ActiveCoverage[i]));
        }
        Assert.NotNull(model.Coinsurance);
        Assert.Equal(expectedCoinsurance.Count, model.Coinsurance.Count);
        for (int i = 0; i < expectedCoinsurance.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedCoinsurance[i], model.Coinsurance[i]));
        }
        Assert.NotNull(model.Deductible);
        Assert.Equal(expectedDeductible.Count, model.Deductible.Count);
        for (int i = 0; i < expectedDeductible.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedDeductible[i], model.Deductible[i]));
        }
        Assert.NotNull(model.Limitations);
        Assert.Equal(expectedLimitations.Count, model.Limitations.Count);
        for (int i = 0; i < expectedLimitations.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedLimitations[i], model.Limitations[i]));
        }
        Assert.NotNull(model.Maximums);
        Assert.Equal(expectedMaximums.Count, model.Maximums.Count);
        for (int i = 0; i < expectedMaximums.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedMaximums[i], model.Maximums[i]));
        }
        Assert.NotNull(model.NotCovered);
        Assert.Equal(expectedNotCovered.Count, model.NotCovered.Count);
        for (int i = 0; i < expectedNotCovered.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedNotCovered[i], model.NotCovered[i]));
        }
        Assert.NotNull(model.Patient);
        Assert.True(JsonElement.DeepEquals(expectedPatient, model.Patient.Value));
        Assert.NotNull(model.Payer);
        Assert.True(JsonElement.DeepEquals(expectedPayer, model.Payer.Value));
        Assert.NotNull(model.Plan);
        Assert.True(JsonElement.DeepEquals(expectedPlan, model.Plan.Value));
        Assert.NotNull(model.Provider);
        Assert.True(JsonElement.DeepEquals(expectedProvider, model.Provider.Value));
        Assert.NotNull(model.Subscriber);
        Assert.True(JsonElement.DeepEquals(expectedSubscriber, model.Subscriber.Value));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ApidentalPostEligibility
        {
            ActiveCoverage = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Coinsurance = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Deductible = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Limitations = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Maximums = [JsonSerializer.Deserialize<JsonElement>("{}")],
            NotCovered = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Patient = JsonSerializer.Deserialize<JsonElement>("{}"),
            Payer = JsonSerializer.Deserialize<JsonElement>("{}"),
            Plan = JsonSerializer.Deserialize<JsonElement>("{}"),
            Provider = JsonSerializer.Deserialize<JsonElement>("{}"),
            Subscriber = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApidentalPostEligibility>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ApidentalPostEligibility
        {
            ActiveCoverage = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Coinsurance = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Deductible = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Limitations = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Maximums = [JsonSerializer.Deserialize<JsonElement>("{}")],
            NotCovered = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Patient = JsonSerializer.Deserialize<JsonElement>("{}"),
            Payer = JsonSerializer.Deserialize<JsonElement>("{}"),
            Plan = JsonSerializer.Deserialize<JsonElement>("{}"),
            Provider = JsonSerializer.Deserialize<JsonElement>("{}"),
            Subscriber = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApidentalPostEligibility>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<JsonElement> expectedActiveCoverage = [JsonSerializer.Deserialize<JsonElement>("{}")];
        List<JsonElement> expectedCoinsurance = [JsonSerializer.Deserialize<JsonElement>("{}")];
        List<JsonElement> expectedDeductible = [JsonSerializer.Deserialize<JsonElement>("{}")];
        List<JsonElement> expectedLimitations = [JsonSerializer.Deserialize<JsonElement>("{}")];
        List<JsonElement> expectedMaximums = [JsonSerializer.Deserialize<JsonElement>("{}")];
        List<JsonElement> expectedNotCovered = [JsonSerializer.Deserialize<JsonElement>("{}")];
        JsonElement expectedPatient = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedPayer = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedPlan = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedProvider = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedSubscriber = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.NotNull(deserialized.ActiveCoverage);
        Assert.Equal(expectedActiveCoverage.Count, deserialized.ActiveCoverage.Count);
        for (int i = 0; i < expectedActiveCoverage.Count; i++)
        {
            Assert.True(
                JsonElement.DeepEquals(expectedActiveCoverage[i], deserialized.ActiveCoverage[i])
            );
        }
        Assert.NotNull(deserialized.Coinsurance);
        Assert.Equal(expectedCoinsurance.Count, deserialized.Coinsurance.Count);
        for (int i = 0; i < expectedCoinsurance.Count; i++)
        {
            Assert.True(
                JsonElement.DeepEquals(expectedCoinsurance[i], deserialized.Coinsurance[i])
            );
        }
        Assert.NotNull(deserialized.Deductible);
        Assert.Equal(expectedDeductible.Count, deserialized.Deductible.Count);
        for (int i = 0; i < expectedDeductible.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedDeductible[i], deserialized.Deductible[i]));
        }
        Assert.NotNull(deserialized.Limitations);
        Assert.Equal(expectedLimitations.Count, deserialized.Limitations.Count);
        for (int i = 0; i < expectedLimitations.Count; i++)
        {
            Assert.True(
                JsonElement.DeepEquals(expectedLimitations[i], deserialized.Limitations[i])
            );
        }
        Assert.NotNull(deserialized.Maximums);
        Assert.Equal(expectedMaximums.Count, deserialized.Maximums.Count);
        for (int i = 0; i < expectedMaximums.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedMaximums[i], deserialized.Maximums[i]));
        }
        Assert.NotNull(deserialized.NotCovered);
        Assert.Equal(expectedNotCovered.Count, deserialized.NotCovered.Count);
        for (int i = 0; i < expectedNotCovered.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedNotCovered[i], deserialized.NotCovered[i]));
        }
        Assert.NotNull(deserialized.Patient);
        Assert.True(JsonElement.DeepEquals(expectedPatient, deserialized.Patient.Value));
        Assert.NotNull(deserialized.Payer);
        Assert.True(JsonElement.DeepEquals(expectedPayer, deserialized.Payer.Value));
        Assert.NotNull(deserialized.Plan);
        Assert.True(JsonElement.DeepEquals(expectedPlan, deserialized.Plan.Value));
        Assert.NotNull(deserialized.Provider);
        Assert.True(JsonElement.DeepEquals(expectedProvider, deserialized.Provider.Value));
        Assert.NotNull(deserialized.Subscriber);
        Assert.True(JsonElement.DeepEquals(expectedSubscriber, deserialized.Subscriber.Value));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ApidentalPostEligibility
        {
            ActiveCoverage = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Coinsurance = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Deductible = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Limitations = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Maximums = [JsonSerializer.Deserialize<JsonElement>("{}")],
            NotCovered = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Patient = JsonSerializer.Deserialize<JsonElement>("{}"),
            Payer = JsonSerializer.Deserialize<JsonElement>("{}"),
            Plan = JsonSerializer.Deserialize<JsonElement>("{}"),
            Provider = JsonSerializer.Deserialize<JsonElement>("{}"),
            Subscriber = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ApidentalPostEligibility { };

        Assert.Null(model.ActiveCoverage);
        Assert.False(model.RawData.ContainsKey("active_coverage"));
        Assert.Null(model.Coinsurance);
        Assert.False(model.RawData.ContainsKey("coinsurance"));
        Assert.Null(model.Deductible);
        Assert.False(model.RawData.ContainsKey("deductible"));
        Assert.Null(model.Limitations);
        Assert.False(model.RawData.ContainsKey("limitations"));
        Assert.Null(model.Maximums);
        Assert.False(model.RawData.ContainsKey("maximums"));
        Assert.Null(model.NotCovered);
        Assert.False(model.RawData.ContainsKey("not_covered"));
        Assert.Null(model.Patient);
        Assert.False(model.RawData.ContainsKey("patient"));
        Assert.Null(model.Payer);
        Assert.False(model.RawData.ContainsKey("payer"));
        Assert.Null(model.Plan);
        Assert.False(model.RawData.ContainsKey("plan"));
        Assert.Null(model.Provider);
        Assert.False(model.RawData.ContainsKey("provider"));
        Assert.Null(model.Subscriber);
        Assert.False(model.RawData.ContainsKey("subscriber"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ApidentalPostEligibility { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ApidentalPostEligibility
        {
            // Null should be interpreted as omitted for these properties
            ActiveCoverage = null,
            Coinsurance = null,
            Deductible = null,
            Limitations = null,
            Maximums = null,
            NotCovered = null,
            Patient = null,
            Payer = null,
            Plan = null,
            Provider = null,
            Subscriber = null,
        };

        Assert.Null(model.ActiveCoverage);
        Assert.False(model.RawData.ContainsKey("active_coverage"));
        Assert.Null(model.Coinsurance);
        Assert.False(model.RawData.ContainsKey("coinsurance"));
        Assert.Null(model.Deductible);
        Assert.False(model.RawData.ContainsKey("deductible"));
        Assert.Null(model.Limitations);
        Assert.False(model.RawData.ContainsKey("limitations"));
        Assert.Null(model.Maximums);
        Assert.False(model.RawData.ContainsKey("maximums"));
        Assert.Null(model.NotCovered);
        Assert.False(model.RawData.ContainsKey("not_covered"));
        Assert.Null(model.Patient);
        Assert.False(model.RawData.ContainsKey("patient"));
        Assert.Null(model.Payer);
        Assert.False(model.RawData.ContainsKey("payer"));
        Assert.Null(model.Plan);
        Assert.False(model.RawData.ContainsKey("plan"));
        Assert.Null(model.Provider);
        Assert.False(model.RawData.ContainsKey("provider"));
        Assert.Null(model.Subscriber);
        Assert.False(model.RawData.ContainsKey("subscriber"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ApidentalPostEligibility
        {
            // Null should be interpreted as omitted for these properties
            ActiveCoverage = null,
            Coinsurance = null,
            Deductible = null,
            Limitations = null,
            Maximums = null,
            NotCovered = null,
            Patient = null,
            Payer = null,
            Plan = null,
            Provider = null,
            Subscriber = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ApidentalPostEligibility
        {
            ActiveCoverage = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Coinsurance = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Deductible = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Limitations = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Maximums = [JsonSerializer.Deserialize<JsonElement>("{}")],
            NotCovered = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Patient = JsonSerializer.Deserialize<JsonElement>("{}"),
            Payer = JsonSerializer.Deserialize<JsonElement>("{}"),
            Plan = JsonSerializer.Deserialize<JsonElement>("{}"),
            Provider = JsonSerializer.Deserialize<JsonElement>("{}"),
            Subscriber = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        ApidentalPostEligibility copied = new(model);

        Assert.Equal(model, copied);
    }
}
