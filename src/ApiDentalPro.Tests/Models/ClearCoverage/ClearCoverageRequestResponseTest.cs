using System.Collections.Generic;
using System.Text.Json;
using ApiDentalPro.Core;
using ApiDentalPro.Models.ClearCoverage;

namespace ApiDentalPro.Tests.Models.ClearCoverage;

public class ClearCoverageRequestResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ClearCoverageRequestResponse
        {
            Data = new()
            {
                ClearcoveragePostEnhancedEligibility = new()
                {
                    Benefits = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    Coverages = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Deductible = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Maximums = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Payer = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Plan = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Provider = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Rules = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Subscriber = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            },
        };

        Data expectedData = new()
        {
            ClearcoveragePostEnhancedEligibility = new()
            {
                Benefits = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Coverages = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Deductible = JsonSerializer.Deserialize<JsonElement>("{}"),
                Maximums = JsonSerializer.Deserialize<JsonElement>("{}"),
                Payer = JsonSerializer.Deserialize<JsonElement>("{}"),
                Plan = JsonSerializer.Deserialize<JsonElement>("{}"),
                Provider = JsonSerializer.Deserialize<JsonElement>("{}"),
                Rules = JsonSerializer.Deserialize<JsonElement>("{}"),
                Subscriber = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ClearCoverageRequestResponse
        {
            Data = new()
            {
                ClearcoveragePostEnhancedEligibility = new()
                {
                    Benefits = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    Coverages = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Deductible = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Maximums = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Payer = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Plan = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Provider = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Rules = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Subscriber = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClearCoverageRequestResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ClearCoverageRequestResponse
        {
            Data = new()
            {
                ClearcoveragePostEnhancedEligibility = new()
                {
                    Benefits = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    Coverages = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Deductible = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Maximums = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Payer = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Plan = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Provider = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Rules = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Subscriber = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClearCoverageRequestResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Data expectedData = new()
        {
            ClearcoveragePostEnhancedEligibility = new()
            {
                Benefits = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Coverages = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Deductible = JsonSerializer.Deserialize<JsonElement>("{}"),
                Maximums = JsonSerializer.Deserialize<JsonElement>("{}"),
                Payer = JsonSerializer.Deserialize<JsonElement>("{}"),
                Plan = JsonSerializer.Deserialize<JsonElement>("{}"),
                Provider = JsonSerializer.Deserialize<JsonElement>("{}"),
                Rules = JsonSerializer.Deserialize<JsonElement>("{}"),
                Subscriber = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ClearCoverageRequestResponse
        {
            Data = new()
            {
                ClearcoveragePostEnhancedEligibility = new()
                {
                    Benefits = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    Coverages = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Deductible = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Maximums = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Payer = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Plan = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Provider = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Rules = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Subscriber = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ClearCoverageRequestResponse { };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ClearCoverageRequestResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ClearCoverageRequestResponse
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
        var model = new ClearCoverageRequestResponse
        {
            // Null should be interpreted as omitted for these properties
            Data = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ClearCoverageRequestResponse
        {
            Data = new()
            {
                ClearcoveragePostEnhancedEligibility = new()
                {
                    Benefits = [JsonSerializer.Deserialize<JsonElement>("{}")],
                    Coverages = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Deductible = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Maximums = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Payer = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Plan = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Provider = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Rules = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Subscriber = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            },
        };

        ClearCoverageRequestResponse copied = new(model);

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
            ClearcoveragePostEnhancedEligibility = new()
            {
                Benefits = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Coverages = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Deductible = JsonSerializer.Deserialize<JsonElement>("{}"),
                Maximums = JsonSerializer.Deserialize<JsonElement>("{}"),
                Payer = JsonSerializer.Deserialize<JsonElement>("{}"),
                Plan = JsonSerializer.Deserialize<JsonElement>("{}"),
                Provider = JsonSerializer.Deserialize<JsonElement>("{}"),
                Rules = JsonSerializer.Deserialize<JsonElement>("{}"),
                Subscriber = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
        };

        ClearcoveragePostEnhancedEligibility expectedClearcoveragePostEnhancedEligibility = new()
        {
            Benefits = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Coverages = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Deductible = JsonSerializer.Deserialize<JsonElement>("{}"),
            Maximums = JsonSerializer.Deserialize<JsonElement>("{}"),
            Payer = JsonSerializer.Deserialize<JsonElement>("{}"),
            Plan = JsonSerializer.Deserialize<JsonElement>("{}"),
            Provider = JsonSerializer.Deserialize<JsonElement>("{}"),
            Rules = JsonSerializer.Deserialize<JsonElement>("{}"),
            Subscriber = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        Assert.Equal(
            expectedClearcoveragePostEnhancedEligibility,
            model.ClearcoveragePostEnhancedEligibility
        );
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
        {
            ClearcoveragePostEnhancedEligibility = new()
            {
                Benefits = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Coverages = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Deductible = JsonSerializer.Deserialize<JsonElement>("{}"),
                Maximums = JsonSerializer.Deserialize<JsonElement>("{}"),
                Payer = JsonSerializer.Deserialize<JsonElement>("{}"),
                Plan = JsonSerializer.Deserialize<JsonElement>("{}"),
                Provider = JsonSerializer.Deserialize<JsonElement>("{}"),
                Rules = JsonSerializer.Deserialize<JsonElement>("{}"),
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
            ClearcoveragePostEnhancedEligibility = new()
            {
                Benefits = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Coverages = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Deductible = JsonSerializer.Deserialize<JsonElement>("{}"),
                Maximums = JsonSerializer.Deserialize<JsonElement>("{}"),
                Payer = JsonSerializer.Deserialize<JsonElement>("{}"),
                Plan = JsonSerializer.Deserialize<JsonElement>("{}"),
                Provider = JsonSerializer.Deserialize<JsonElement>("{}"),
                Rules = JsonSerializer.Deserialize<JsonElement>("{}"),
                Subscriber = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        ClearcoveragePostEnhancedEligibility expectedClearcoveragePostEnhancedEligibility = new()
        {
            Benefits = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Coverages = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Deductible = JsonSerializer.Deserialize<JsonElement>("{}"),
            Maximums = JsonSerializer.Deserialize<JsonElement>("{}"),
            Payer = JsonSerializer.Deserialize<JsonElement>("{}"),
            Plan = JsonSerializer.Deserialize<JsonElement>("{}"),
            Provider = JsonSerializer.Deserialize<JsonElement>("{}"),
            Rules = JsonSerializer.Deserialize<JsonElement>("{}"),
            Subscriber = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        Assert.Equal(
            expectedClearcoveragePostEnhancedEligibility,
            deserialized.ClearcoveragePostEnhancedEligibility
        );
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
        {
            ClearcoveragePostEnhancedEligibility = new()
            {
                Benefits = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Coverages = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Deductible = JsonSerializer.Deserialize<JsonElement>("{}"),
                Maximums = JsonSerializer.Deserialize<JsonElement>("{}"),
                Payer = JsonSerializer.Deserialize<JsonElement>("{}"),
                Plan = JsonSerializer.Deserialize<JsonElement>("{}"),
                Provider = JsonSerializer.Deserialize<JsonElement>("{}"),
                Rules = JsonSerializer.Deserialize<JsonElement>("{}"),
                Subscriber = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Data { };

        Assert.Null(model.ClearcoveragePostEnhancedEligibility);
        Assert.False(model.RawData.ContainsKey("clearcoverage_post_enhanced_eligibility"));
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
            ClearcoveragePostEnhancedEligibility = null,
        };

        Assert.Null(model.ClearcoveragePostEnhancedEligibility);
        Assert.False(model.RawData.ContainsKey("clearcoverage_post_enhanced_eligibility"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Data
        {
            // Null should be interpreted as omitted for these properties
            ClearcoveragePostEnhancedEligibility = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data
        {
            ClearcoveragePostEnhancedEligibility = new()
            {
                Benefits = [JsonSerializer.Deserialize<JsonElement>("{}")],
                Coverages = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Deductible = JsonSerializer.Deserialize<JsonElement>("{}"),
                Maximums = JsonSerializer.Deserialize<JsonElement>("{}"),
                Payer = JsonSerializer.Deserialize<JsonElement>("{}"),
                Plan = JsonSerializer.Deserialize<JsonElement>("{}"),
                Provider = JsonSerializer.Deserialize<JsonElement>("{}"),
                Rules = JsonSerializer.Deserialize<JsonElement>("{}"),
                Subscriber = JsonSerializer.Deserialize<JsonElement>("{}"),
            },
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ClearcoveragePostEnhancedEligibilityTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ClearcoveragePostEnhancedEligibility
        {
            Benefits = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Coverages = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Deductible = JsonSerializer.Deserialize<JsonElement>("{}"),
            Maximums = JsonSerializer.Deserialize<JsonElement>("{}"),
            Payer = JsonSerializer.Deserialize<JsonElement>("{}"),
            Plan = JsonSerializer.Deserialize<JsonElement>("{}"),
            Provider = JsonSerializer.Deserialize<JsonElement>("{}"),
            Rules = JsonSerializer.Deserialize<JsonElement>("{}"),
            Subscriber = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        List<JsonElement> expectedBenefits = [JsonSerializer.Deserialize<JsonElement>("{}")];
        Dictionary<string, JsonElement> expectedCoverages = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        JsonElement expectedDeductible = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedMaximums = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedPayer = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedPlan = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedProvider = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedRules = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedSubscriber = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.NotNull(model.Benefits);
        Assert.Equal(expectedBenefits.Count, model.Benefits.Count);
        for (int i = 0; i < expectedBenefits.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedBenefits[i], model.Benefits[i]));
        }
        Assert.NotNull(model.Coverages);
        Assert.Equal(expectedCoverages.Count, model.Coverages.Count);
        foreach (var item in expectedCoverages)
        {
            Assert.True(model.Coverages.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Coverages[item.Key]));
        }
        Assert.NotNull(model.Deductible);
        Assert.True(JsonElement.DeepEquals(expectedDeductible, model.Deductible.Value));
        Assert.NotNull(model.Maximums);
        Assert.True(JsonElement.DeepEquals(expectedMaximums, model.Maximums.Value));
        Assert.NotNull(model.Payer);
        Assert.True(JsonElement.DeepEquals(expectedPayer, model.Payer.Value));
        Assert.NotNull(model.Plan);
        Assert.True(JsonElement.DeepEquals(expectedPlan, model.Plan.Value));
        Assert.NotNull(model.Provider);
        Assert.True(JsonElement.DeepEquals(expectedProvider, model.Provider.Value));
        Assert.NotNull(model.Rules);
        Assert.True(JsonElement.DeepEquals(expectedRules, model.Rules.Value));
        Assert.NotNull(model.Subscriber);
        Assert.True(JsonElement.DeepEquals(expectedSubscriber, model.Subscriber.Value));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ClearcoveragePostEnhancedEligibility
        {
            Benefits = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Coverages = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Deductible = JsonSerializer.Deserialize<JsonElement>("{}"),
            Maximums = JsonSerializer.Deserialize<JsonElement>("{}"),
            Payer = JsonSerializer.Deserialize<JsonElement>("{}"),
            Plan = JsonSerializer.Deserialize<JsonElement>("{}"),
            Provider = JsonSerializer.Deserialize<JsonElement>("{}"),
            Rules = JsonSerializer.Deserialize<JsonElement>("{}"),
            Subscriber = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClearcoveragePostEnhancedEligibility>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ClearcoveragePostEnhancedEligibility
        {
            Benefits = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Coverages = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Deductible = JsonSerializer.Deserialize<JsonElement>("{}"),
            Maximums = JsonSerializer.Deserialize<JsonElement>("{}"),
            Payer = JsonSerializer.Deserialize<JsonElement>("{}"),
            Plan = JsonSerializer.Deserialize<JsonElement>("{}"),
            Provider = JsonSerializer.Deserialize<JsonElement>("{}"),
            Rules = JsonSerializer.Deserialize<JsonElement>("{}"),
            Subscriber = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClearcoveragePostEnhancedEligibility>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<JsonElement> expectedBenefits = [JsonSerializer.Deserialize<JsonElement>("{}")];
        Dictionary<string, JsonElement> expectedCoverages = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        JsonElement expectedDeductible = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedMaximums = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedPayer = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedPlan = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedProvider = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedRules = JsonSerializer.Deserialize<JsonElement>("{}");
        JsonElement expectedSubscriber = JsonSerializer.Deserialize<JsonElement>("{}");

        Assert.NotNull(deserialized.Benefits);
        Assert.Equal(expectedBenefits.Count, deserialized.Benefits.Count);
        for (int i = 0; i < expectedBenefits.Count; i++)
        {
            Assert.True(JsonElement.DeepEquals(expectedBenefits[i], deserialized.Benefits[i]));
        }
        Assert.NotNull(deserialized.Coverages);
        Assert.Equal(expectedCoverages.Count, deserialized.Coverages.Count);
        foreach (var item in expectedCoverages)
        {
            Assert.True(deserialized.Coverages.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Coverages[item.Key]));
        }
        Assert.NotNull(deserialized.Deductible);
        Assert.True(JsonElement.DeepEquals(expectedDeductible, deserialized.Deductible.Value));
        Assert.NotNull(deserialized.Maximums);
        Assert.True(JsonElement.DeepEquals(expectedMaximums, deserialized.Maximums.Value));
        Assert.NotNull(deserialized.Payer);
        Assert.True(JsonElement.DeepEquals(expectedPayer, deserialized.Payer.Value));
        Assert.NotNull(deserialized.Plan);
        Assert.True(JsonElement.DeepEquals(expectedPlan, deserialized.Plan.Value));
        Assert.NotNull(deserialized.Provider);
        Assert.True(JsonElement.DeepEquals(expectedProvider, deserialized.Provider.Value));
        Assert.NotNull(deserialized.Rules);
        Assert.True(JsonElement.DeepEquals(expectedRules, deserialized.Rules.Value));
        Assert.NotNull(deserialized.Subscriber);
        Assert.True(JsonElement.DeepEquals(expectedSubscriber, deserialized.Subscriber.Value));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ClearcoveragePostEnhancedEligibility
        {
            Benefits = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Coverages = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Deductible = JsonSerializer.Deserialize<JsonElement>("{}"),
            Maximums = JsonSerializer.Deserialize<JsonElement>("{}"),
            Payer = JsonSerializer.Deserialize<JsonElement>("{}"),
            Plan = JsonSerializer.Deserialize<JsonElement>("{}"),
            Provider = JsonSerializer.Deserialize<JsonElement>("{}"),
            Rules = JsonSerializer.Deserialize<JsonElement>("{}"),
            Subscriber = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ClearcoveragePostEnhancedEligibility { };

        Assert.Null(model.Benefits);
        Assert.False(model.RawData.ContainsKey("benefits"));
        Assert.Null(model.Coverages);
        Assert.False(model.RawData.ContainsKey("coverages"));
        Assert.Null(model.Deductible);
        Assert.False(model.RawData.ContainsKey("deductible"));
        Assert.Null(model.Maximums);
        Assert.False(model.RawData.ContainsKey("maximums"));
        Assert.Null(model.Payer);
        Assert.False(model.RawData.ContainsKey("payer"));
        Assert.Null(model.Plan);
        Assert.False(model.RawData.ContainsKey("plan"));
        Assert.Null(model.Provider);
        Assert.False(model.RawData.ContainsKey("provider"));
        Assert.Null(model.Rules);
        Assert.False(model.RawData.ContainsKey("rules"));
        Assert.Null(model.Subscriber);
        Assert.False(model.RawData.ContainsKey("subscriber"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ClearcoveragePostEnhancedEligibility { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ClearcoveragePostEnhancedEligibility
        {
            // Null should be interpreted as omitted for these properties
            Benefits = null,
            Coverages = null,
            Deductible = null,
            Maximums = null,
            Payer = null,
            Plan = null,
            Provider = null,
            Rules = null,
            Subscriber = null,
        };

        Assert.Null(model.Benefits);
        Assert.False(model.RawData.ContainsKey("benefits"));
        Assert.Null(model.Coverages);
        Assert.False(model.RawData.ContainsKey("coverages"));
        Assert.Null(model.Deductible);
        Assert.False(model.RawData.ContainsKey("deductible"));
        Assert.Null(model.Maximums);
        Assert.False(model.RawData.ContainsKey("maximums"));
        Assert.Null(model.Payer);
        Assert.False(model.RawData.ContainsKey("payer"));
        Assert.Null(model.Plan);
        Assert.False(model.RawData.ContainsKey("plan"));
        Assert.Null(model.Provider);
        Assert.False(model.RawData.ContainsKey("provider"));
        Assert.Null(model.Rules);
        Assert.False(model.RawData.ContainsKey("rules"));
        Assert.Null(model.Subscriber);
        Assert.False(model.RawData.ContainsKey("subscriber"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ClearcoveragePostEnhancedEligibility
        {
            // Null should be interpreted as omitted for these properties
            Benefits = null,
            Coverages = null,
            Deductible = null,
            Maximums = null,
            Payer = null,
            Plan = null,
            Provider = null,
            Rules = null,
            Subscriber = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ClearcoveragePostEnhancedEligibility
        {
            Benefits = [JsonSerializer.Deserialize<JsonElement>("{}")],
            Coverages = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Deductible = JsonSerializer.Deserialize<JsonElement>("{}"),
            Maximums = JsonSerializer.Deserialize<JsonElement>("{}"),
            Payer = JsonSerializer.Deserialize<JsonElement>("{}"),
            Plan = JsonSerializer.Deserialize<JsonElement>("{}"),
            Provider = JsonSerializer.Deserialize<JsonElement>("{}"),
            Rules = JsonSerializer.Deserialize<JsonElement>("{}"),
            Subscriber = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        ClearcoveragePostEnhancedEligibility copied = new(model);

        Assert.Equal(model, copied);
    }
}
