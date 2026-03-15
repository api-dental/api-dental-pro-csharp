using System.Collections.Generic;
using System.Text.Json;
using ApiDentalPro.Core;
using ApiDentalPro.Exceptions;
using ApiDentalPro.Models.Payer;

namespace ApiDentalPro.Tests.Models.Payer;

public class PayerListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PayerListResponse
        {
            Data = new()
            {
                ApidentalPayerList =
                [
                    new()
                    {
                        ID = "id",
                        AltPayerIds = ["string"],
                        Features = ["string"],
                        Name = "name",
                        OnederfulPayerID = "onederfulPayerId",
                        Status = Status.Active,
                    },
                ],
            },
        };

        Data expectedData = new()
        {
            ApidentalPayerList =
            [
                new()
                {
                    ID = "id",
                    AltPayerIds = ["string"],
                    Features = ["string"],
                    Name = "name",
                    OnederfulPayerID = "onederfulPayerId",
                    Status = Status.Active,
                },
            ],
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PayerListResponse
        {
            Data = new()
            {
                ApidentalPayerList =
                [
                    new()
                    {
                        ID = "id",
                        AltPayerIds = ["string"],
                        Features = ["string"],
                        Name = "name",
                        OnederfulPayerID = "onederfulPayerId",
                        Status = Status.Active,
                    },
                ],
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PayerListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PayerListResponse
        {
            Data = new()
            {
                ApidentalPayerList =
                [
                    new()
                    {
                        ID = "id",
                        AltPayerIds = ["string"],
                        Features = ["string"],
                        Name = "name",
                        OnederfulPayerID = "onederfulPayerId",
                        Status = Status.Active,
                    },
                ],
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PayerListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Data expectedData = new()
        {
            ApidentalPayerList =
            [
                new()
                {
                    ID = "id",
                    AltPayerIds = ["string"],
                    Features = ["string"],
                    Name = "name",
                    OnederfulPayerID = "onederfulPayerId",
                    Status = Status.Active,
                },
            ],
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PayerListResponse
        {
            Data = new()
            {
                ApidentalPayerList =
                [
                    new()
                    {
                        ID = "id",
                        AltPayerIds = ["string"],
                        Features = ["string"],
                        Name = "name",
                        OnederfulPayerID = "onederfulPayerId",
                        Status = Status.Active,
                    },
                ],
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PayerListResponse { };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
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
            Data = null,
        };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PayerListResponse
        {
            // Null should be interpreted as omitted for these properties
            Data = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PayerListResponse
        {
            Data = new()
            {
                ApidentalPayerList =
                [
                    new()
                    {
                        ID = "id",
                        AltPayerIds = ["string"],
                        Features = ["string"],
                        Name = "name",
                        OnederfulPayerID = "onederfulPayerId",
                        Status = Status.Active,
                    },
                ],
            },
        };

        PayerListResponse copied = new(model);

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
            ApidentalPayerList =
            [
                new()
                {
                    ID = "id",
                    AltPayerIds = ["string"],
                    Features = ["string"],
                    Name = "name",
                    OnederfulPayerID = "onederfulPayerId",
                    Status = Status.Active,
                },
            ],
        };

        List<ApidentalPayerList> expectedApidentalPayerList =
        [
            new()
            {
                ID = "id",
                AltPayerIds = ["string"],
                Features = ["string"],
                Name = "name",
                OnederfulPayerID = "onederfulPayerId",
                Status = Status.Active,
            },
        ];

        Assert.NotNull(model.ApidentalPayerList);
        Assert.Equal(expectedApidentalPayerList.Count, model.ApidentalPayerList.Count);
        for (int i = 0; i < expectedApidentalPayerList.Count; i++)
        {
            Assert.Equal(expectedApidentalPayerList[i], model.ApidentalPayerList[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
        {
            ApidentalPayerList =
            [
                new()
                {
                    ID = "id",
                    AltPayerIds = ["string"],
                    Features = ["string"],
                    Name = "name",
                    OnederfulPayerID = "onederfulPayerId",
                    Status = Status.Active,
                },
            ],
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
            ApidentalPayerList =
            [
                new()
                {
                    ID = "id",
                    AltPayerIds = ["string"],
                    Features = ["string"],
                    Name = "name",
                    OnederfulPayerID = "onederfulPayerId",
                    Status = Status.Active,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<ApidentalPayerList> expectedApidentalPayerList =
        [
            new()
            {
                ID = "id",
                AltPayerIds = ["string"],
                Features = ["string"],
                Name = "name",
                OnederfulPayerID = "onederfulPayerId",
                Status = Status.Active,
            },
        ];

        Assert.NotNull(deserialized.ApidentalPayerList);
        Assert.Equal(expectedApidentalPayerList.Count, deserialized.ApidentalPayerList.Count);
        for (int i = 0; i < expectedApidentalPayerList.Count; i++)
        {
            Assert.Equal(expectedApidentalPayerList[i], deserialized.ApidentalPayerList[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
        {
            ApidentalPayerList =
            [
                new()
                {
                    ID = "id",
                    AltPayerIds = ["string"],
                    Features = ["string"],
                    Name = "name",
                    OnederfulPayerID = "onederfulPayerId",
                    Status = Status.Active,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Data { };

        Assert.Null(model.ApidentalPayerList);
        Assert.False(model.RawData.ContainsKey("apidental_payer_list"));
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
            ApidentalPayerList = null,
        };

        Assert.Null(model.ApidentalPayerList);
        Assert.False(model.RawData.ContainsKey("apidental_payer_list"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Data
        {
            // Null should be interpreted as omitted for these properties
            ApidentalPayerList = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data
        {
            ApidentalPayerList =
            [
                new()
                {
                    ID = "id",
                    AltPayerIds = ["string"],
                    Features = ["string"],
                    Name = "name",
                    OnederfulPayerID = "onederfulPayerId",
                    Status = Status.Active,
                },
            ],
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ApidentalPayerListTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ApidentalPayerList
        {
            ID = "id",
            AltPayerIds = ["string"],
            Features = ["string"],
            Name = "name",
            OnederfulPayerID = "onederfulPayerId",
            Status = Status.Active,
        };

        string expectedID = "id";
        List<string> expectedAltPayerIds = ["string"];
        List<string> expectedFeatures = ["string"];
        string expectedName = "name";
        string expectedOnederfulPayerID = "onederfulPayerId";
        ApiEnum<string, Status> expectedStatus = Status.Active;

        Assert.Equal(expectedID, model.ID);
        Assert.NotNull(model.AltPayerIds);
        Assert.Equal(expectedAltPayerIds.Count, model.AltPayerIds.Count);
        for (int i = 0; i < expectedAltPayerIds.Count; i++)
        {
            Assert.Equal(expectedAltPayerIds[i], model.AltPayerIds[i]);
        }
        Assert.NotNull(model.Features);
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
        var model = new ApidentalPayerList
        {
            ID = "id",
            AltPayerIds = ["string"],
            Features = ["string"],
            Name = "name",
            OnederfulPayerID = "onederfulPayerId",
            Status = Status.Active,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApidentalPayerList>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ApidentalPayerList
        {
            ID = "id",
            AltPayerIds = ["string"],
            Features = ["string"],
            Name = "name",
            OnederfulPayerID = "onederfulPayerId",
            Status = Status.Active,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApidentalPayerList>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        List<string> expectedAltPayerIds = ["string"];
        List<string> expectedFeatures = ["string"];
        string expectedName = "name";
        string expectedOnederfulPayerID = "onederfulPayerId";
        ApiEnum<string, Status> expectedStatus = Status.Active;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.NotNull(deserialized.AltPayerIds);
        Assert.Equal(expectedAltPayerIds.Count, deserialized.AltPayerIds.Count);
        for (int i = 0; i < expectedAltPayerIds.Count; i++)
        {
            Assert.Equal(expectedAltPayerIds[i], deserialized.AltPayerIds[i]);
        }
        Assert.NotNull(deserialized.Features);
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
        var model = new ApidentalPayerList
        {
            ID = "id",
            AltPayerIds = ["string"],
            Features = ["string"],
            Name = "name",
            OnederfulPayerID = "onederfulPayerId",
            Status = Status.Active,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ApidentalPayerList { };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.AltPayerIds);
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
        var model = new ApidentalPayerList { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ApidentalPayerList
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            AltPayerIds = null,
            Features = null,
            Name = null,
            OnederfulPayerID = null,
            Status = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.AltPayerIds);
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
        var model = new ApidentalPayerList
        {
            // Null should be interpreted as omitted for these properties
            ID = null,
            AltPayerIds = null,
            Features = null,
            Name = null,
            OnederfulPayerID = null,
            Status = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ApidentalPayerList
        {
            ID = "id",
            AltPayerIds = ["string"],
            Features = ["string"],
            Name = "name",
            OnederfulPayerID = "onederfulPayerId",
            Status = Status.Active,
        };

        ApidentalPayerList copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Active)]
    [InlineData(Status.Inactive)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ApiDentalProInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Active)]
    [InlineData(Status.Inactive)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
