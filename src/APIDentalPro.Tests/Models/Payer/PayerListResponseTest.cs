using System.Collections.Generic;
using System.Text.Json;
using APIDentalPro.Models.Payer;

namespace APIDentalPro.Tests.Models.Payer;

public class PayerListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PayerListResponse
        {
            ID = "id",
            AltPayerIDs = ["string"],
            Features = ["string"],
            Name = "name",
            OnederfulPayerID = "onederfulPayerId",
            Status = "status",
        };

        string expectedID = "id";
        List<string> expectedAltPayerIDs = ["string"];
        List<string> expectedFeatures = ["string"];
        string expectedName = "name";
        string expectedOnederfulPayerID = "onederfulPayerId";
        string expectedStatus = "status";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAltPayerIDs.Count, model.AltPayerIDs.Count);
        for (int i = 0; i < expectedAltPayerIDs.Count; i++)
        {
            Assert.Equal(expectedAltPayerIDs[i], model.AltPayerIDs[i]);
        }
        Assert.Equal(expectedFeatures.Count, model.Features.Count);
        for (int i = 0; i < expectedFeatures.Count; i++)
        {
            Assert.Equal(expectedFeatures[i], model.Features[i]);
        }
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedOnederfulPayerID, model.OnederfulPayerID);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PayerListResponse
        {
            ID = "id",
            AltPayerIDs = ["string"],
            Features = ["string"],
            Name = "name",
            OnederfulPayerID = "onederfulPayerId",
            Status = "status",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PayerListResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PayerListResponse
        {
            ID = "id",
            AltPayerIDs = ["string"],
            Features = ["string"],
            Name = "name",
            OnederfulPayerID = "onederfulPayerId",
            Status = "status",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PayerListResponse>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        List<string> expectedAltPayerIDs = ["string"];
        List<string> expectedFeatures = ["string"];
        string expectedName = "name";
        string expectedOnederfulPayerID = "onederfulPayerId";
        string expectedStatus = "status";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAltPayerIDs.Count, deserialized.AltPayerIDs.Count);
        for (int i = 0; i < expectedAltPayerIDs.Count; i++)
        {
            Assert.Equal(expectedAltPayerIDs[i], deserialized.AltPayerIDs[i]);
        }
        Assert.Equal(expectedFeatures.Count, deserialized.Features.Count);
        for (int i = 0; i < expectedFeatures.Count; i++)
        {
            Assert.Equal(expectedFeatures[i], deserialized.Features[i]);
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedOnederfulPayerID, deserialized.OnederfulPayerID);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PayerListResponse
        {
            ID = "id",
            AltPayerIDs = ["string"],
            Features = ["string"],
            Name = "name",
            OnederfulPayerID = "onederfulPayerId",
            Status = "status",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PayerListResponse { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.AltPayerIDs);
        Assert.False(model.RawData.ContainsKey("alt_payer_ids"));
        Assert.Null(model.Features);
        Assert.False(model.RawData.ContainsKey("features"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.OnederfulPayerID);
        Assert.False(model.RawData.ContainsKey("onederfulPayerId"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PayerListResponse { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PayerListResponse
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            AltPayerIDs = null,
            Features = null,
            Name = null,
            OnederfulPayerID = null,
            Status = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.AltPayerIDs);
        Assert.False(model.RawData.ContainsKey("alt_payer_ids"));
        Assert.Null(model.Features);
        Assert.False(model.RawData.ContainsKey("features"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.OnederfulPayerID);
        Assert.False(model.RawData.ContainsKey("onederfulPayerId"));
        Assert.Null(model.Status);
        Assert.False(model.RawData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PayerListResponse
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            AltPayerIDs = null,
            Features = null,
            Name = null,
            OnederfulPayerID = null,
            Status = null,
        };

        model.Validate();
    }
}
