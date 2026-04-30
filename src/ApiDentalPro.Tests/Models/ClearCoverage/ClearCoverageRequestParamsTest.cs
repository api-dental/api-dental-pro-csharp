using System;
using System.Text.Json;
using ApiDentalPro.Core;
using ApiDentalPro.Exceptions;
using ClearCoverage = ApiDentalPro.Models.ClearCoverage;

namespace ApiDentalPro.Tests.Models.ClearCoverage;

public class ClearCoverageRequestParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ClearCoverage::ClearCoverageRequestParams
        {
            Payer = new("52133"),
            Provider = new() { Npi = "1447364856", TaxID = "270872579" },
            Subscriber = new()
            {
                Dob = "01/15/1990",
                FirstName = "John",
                GroupNumber = "GRP001",
                LastName = "Smith",
                MemberID = "123456789",
            },
            Version = ClearCoverage::Version.V2,
            Dependent = new()
            {
                Dob = "dob",
                FirstName = "first_name",
                GroupNumber = "group_number",
                LastName = "last_name",
                MemberID = "member_id",
            },
            LocationID = "location_id",
        };

        ClearCoverage::ClearCoverageRequestParamsPayer expectedPayer = new("52133");
        ClearCoverage::Provider expectedProvider = new()
        {
            Npi = "1447364856",
            TaxID = "270872579",
        };
        ClearCoverage::Subscriber expectedSubscriber = new()
        {
            Dob = "01/15/1990",
            FirstName = "John",
            GroupNumber = "GRP001",
            LastName = "Smith",
            MemberID = "123456789",
        };
        ApiEnum<string, ClearCoverage::Version> expectedVersion = ClearCoverage::Version.V2;
        ClearCoverage::Dependent expectedDependent = new()
        {
            Dob = "dob",
            FirstName = "first_name",
            GroupNumber = "group_number",
            LastName = "last_name",
            MemberID = "member_id",
        };
        string expectedLocationID = "location_id";

        Assert.Equal(expectedPayer, parameters.Payer);
        Assert.Equal(expectedProvider, parameters.Provider);
        Assert.Equal(expectedSubscriber, parameters.Subscriber);
        Assert.Equal(expectedVersion, parameters.Version);
        Assert.Equal(expectedDependent, parameters.Dependent);
        Assert.Equal(expectedLocationID, parameters.LocationID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ClearCoverage::ClearCoverageRequestParams
        {
            Payer = new("52133"),
            Provider = new() { Npi = "1447364856", TaxID = "270872579" },
            Subscriber = new()
            {
                Dob = "01/15/1990",
                FirstName = "John",
                GroupNumber = "GRP001",
                LastName = "Smith",
                MemberID = "123456789",
            },
            Version = ClearCoverage::Version.V2,
        };

        Assert.Null(parameters.Dependent);
        Assert.False(parameters.RawBodyData.ContainsKey("dependent"));
        Assert.Null(parameters.LocationID);
        Assert.False(parameters.RawBodyData.ContainsKey("location_id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ClearCoverage::ClearCoverageRequestParams
        {
            Payer = new("52133"),
            Provider = new() { Npi = "1447364856", TaxID = "270872579" },
            Subscriber = new()
            {
                Dob = "01/15/1990",
                FirstName = "John",
                GroupNumber = "GRP001",
                LastName = "Smith",
                MemberID = "123456789",
            },
            Version = ClearCoverage::Version.V2,

            // Null should be interpreted as omitted for these properties
            Dependent = null,
            LocationID = null,
        };

        Assert.Null(parameters.Dependent);
        Assert.False(parameters.RawBodyData.ContainsKey("dependent"));
        Assert.Null(parameters.LocationID);
        Assert.False(parameters.RawBodyData.ContainsKey("location_id"));
    }

    [Fact]
    public void Url_Works()
    {
        ClearCoverage::ClearCoverageRequestParams parameters = new()
        {
            Payer = new("52133"),
            Provider = new() { Npi = "1447364856", TaxID = "270872579" },
            Subscriber = new()
            {
                Dob = "01/15/1990",
                FirstName = "John",
                GroupNumber = "GRP001",
                LastName = "Smith",
                MemberID = "123456789",
            },
            Version = ClearCoverage::Version.V2,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://wg.api.dental/rest/ClearCoverage"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ClearCoverage::ClearCoverageRequestParams
        {
            Payer = new("52133"),
            Provider = new() { Npi = "1447364856", TaxID = "270872579" },
            Subscriber = new()
            {
                Dob = "01/15/1990",
                FirstName = "John",
                GroupNumber = "GRP001",
                LastName = "Smith",
                MemberID = "123456789",
            },
            Version = ClearCoverage::Version.V2,
            Dependent = new()
            {
                Dob = "dob",
                FirstName = "first_name",
                GroupNumber = "group_number",
                LastName = "last_name",
                MemberID = "member_id",
            },
            LocationID = "location_id",
        };

        ClearCoverage::ClearCoverageRequestParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ClearCoverageRequestParamsPayerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ClearCoverage::ClearCoverageRequestParamsPayer { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, model.ID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ClearCoverage::ClearCoverageRequestParamsPayer { ID = "id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ClearCoverage::ClearCoverageRequestParamsPayer>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ClearCoverage::ClearCoverageRequestParamsPayer { ID = "id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ClearCoverage::ClearCoverageRequestParamsPayer>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "id";

        Assert.Equal(expectedID, deserialized.ID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ClearCoverage::ClearCoverageRequestParamsPayer { ID = "id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ClearCoverage::ClearCoverageRequestParamsPayer { ID = "id" };

        ClearCoverage::ClearCoverageRequestParamsPayer copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProviderTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ClearCoverage::Provider { Npi = "npi", TaxID = "tax_id" };

        string expectedNpi = "npi";
        string expectedTaxID = "tax_id";

        Assert.Equal(expectedNpi, model.Npi);
        Assert.Equal(expectedTaxID, model.TaxID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ClearCoverage::Provider { Npi = "npi", TaxID = "tax_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClearCoverage::Provider>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ClearCoverage::Provider { Npi = "npi", TaxID = "tax_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClearCoverage::Provider>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedNpi = "npi";
        string expectedTaxID = "tax_id";

        Assert.Equal(expectedNpi, deserialized.Npi);
        Assert.Equal(expectedTaxID, deserialized.TaxID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ClearCoverage::Provider { Npi = "npi", TaxID = "tax_id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ClearCoverage::Provider { Npi = "npi", TaxID = "tax_id" };

        ClearCoverage::Provider copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriberTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ClearCoverage::Subscriber
        {
            Dob = "dob",
            FirstName = "first_name",
            GroupNumber = "group_number",
            LastName = "last_name",
            MemberID = "member_id",
        };

        string expectedDob = "dob";
        string expectedFirstName = "first_name";
        string expectedGroupNumber = "group_number";
        string expectedLastName = "last_name";
        string expectedMemberID = "member_id";

        Assert.Equal(expectedDob, model.Dob);
        Assert.Equal(expectedFirstName, model.FirstName);
        Assert.Equal(expectedGroupNumber, model.GroupNumber);
        Assert.Equal(expectedLastName, model.LastName);
        Assert.Equal(expectedMemberID, model.MemberID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ClearCoverage::Subscriber
        {
            Dob = "dob",
            FirstName = "first_name",
            GroupNumber = "group_number",
            LastName = "last_name",
            MemberID = "member_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClearCoverage::Subscriber>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ClearCoverage::Subscriber
        {
            Dob = "dob",
            FirstName = "first_name",
            GroupNumber = "group_number",
            LastName = "last_name",
            MemberID = "member_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClearCoverage::Subscriber>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDob = "dob";
        string expectedFirstName = "first_name";
        string expectedGroupNumber = "group_number";
        string expectedLastName = "last_name";
        string expectedMemberID = "member_id";

        Assert.Equal(expectedDob, deserialized.Dob);
        Assert.Equal(expectedFirstName, deserialized.FirstName);
        Assert.Equal(expectedGroupNumber, deserialized.GroupNumber);
        Assert.Equal(expectedLastName, deserialized.LastName);
        Assert.Equal(expectedMemberID, deserialized.MemberID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ClearCoverage::Subscriber
        {
            Dob = "dob",
            FirstName = "first_name",
            GroupNumber = "group_number",
            LastName = "last_name",
            MemberID = "member_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ClearCoverage::Subscriber
        {
            Dob = "dob",
            FirstName = "first_name",
            GroupNumber = "group_number",
            LastName = "last_name",
            MemberID = "member_id",
        };

        ClearCoverage::Subscriber copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VersionTest : TestBase
{
    [Theory]
    [InlineData(ClearCoverage::Version.V1)]
    [InlineData(ClearCoverage::Version.V2)]
    public void Validation_Works(ClearCoverage::Version rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ClearCoverage::Version> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ClearCoverage::Version>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ApiDentalProInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ClearCoverage::Version.V1)]
    [InlineData(ClearCoverage::Version.V2)]
    public void SerializationRoundtrip_Works(ClearCoverage::Version rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ClearCoverage::Version> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ClearCoverage::Version>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ClearCoverage::Version>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ClearCoverage::Version>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DependentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ClearCoverage::Dependent
        {
            Dob = "dob",
            FirstName = "first_name",
            GroupNumber = "group_number",
            LastName = "last_name",
            MemberID = "member_id",
        };

        string expectedDob = "dob";
        string expectedFirstName = "first_name";
        string expectedGroupNumber = "group_number";
        string expectedLastName = "last_name";
        string expectedMemberID = "member_id";

        Assert.Equal(expectedDob, model.Dob);
        Assert.Equal(expectedFirstName, model.FirstName);
        Assert.Equal(expectedGroupNumber, model.GroupNumber);
        Assert.Equal(expectedLastName, model.LastName);
        Assert.Equal(expectedMemberID, model.MemberID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ClearCoverage::Dependent
        {
            Dob = "dob",
            FirstName = "first_name",
            GroupNumber = "group_number",
            LastName = "last_name",
            MemberID = "member_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClearCoverage::Dependent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ClearCoverage::Dependent
        {
            Dob = "dob",
            FirstName = "first_name",
            GroupNumber = "group_number",
            LastName = "last_name",
            MemberID = "member_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClearCoverage::Dependent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDob = "dob";
        string expectedFirstName = "first_name";
        string expectedGroupNumber = "group_number";
        string expectedLastName = "last_name";
        string expectedMemberID = "member_id";

        Assert.Equal(expectedDob, deserialized.Dob);
        Assert.Equal(expectedFirstName, deserialized.FirstName);
        Assert.Equal(expectedGroupNumber, deserialized.GroupNumber);
        Assert.Equal(expectedLastName, deserialized.LastName);
        Assert.Equal(expectedMemberID, deserialized.MemberID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ClearCoverage::Dependent
        {
            Dob = "dob",
            FirstName = "first_name",
            GroupNumber = "group_number",
            LastName = "last_name",
            MemberID = "member_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ClearCoverage::Dependent { };

        Assert.Null(model.Dob);
        Assert.False(model.RawData.ContainsKey("dob"));
        Assert.Null(model.FirstName);
        Assert.False(model.RawData.ContainsKey("first_name"));
        Assert.Null(model.GroupNumber);
        Assert.False(model.RawData.ContainsKey("group_number"));
        Assert.Null(model.LastName);
        Assert.False(model.RawData.ContainsKey("last_name"));
        Assert.Null(model.MemberID);
        Assert.False(model.RawData.ContainsKey("member_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ClearCoverage::Dependent { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ClearCoverage::Dependent
        {
            // Null should be interpreted as omitted for these properties
            Dob = null,
            FirstName = null,
            GroupNumber = null,
            LastName = null,
            MemberID = null,
        };

        Assert.Null(model.Dob);
        Assert.False(model.RawData.ContainsKey("dob"));
        Assert.Null(model.FirstName);
        Assert.False(model.RawData.ContainsKey("first_name"));
        Assert.Null(model.GroupNumber);
        Assert.False(model.RawData.ContainsKey("group_number"));
        Assert.Null(model.LastName);
        Assert.False(model.RawData.ContainsKey("last_name"));
        Assert.Null(model.MemberID);
        Assert.False(model.RawData.ContainsKey("member_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ClearCoverage::Dependent
        {
            // Null should be interpreted as omitted for these properties
            Dob = null,
            FirstName = null,
            GroupNumber = null,
            LastName = null,
            MemberID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ClearCoverage::Dependent
        {
            Dob = "dob",
            FirstName = "first_name",
            GroupNumber = "group_number",
            LastName = "last_name",
            MemberID = "member_id",
        };

        ClearCoverage::Dependent copied = new(model);

        Assert.Equal(model, copied);
    }
}
