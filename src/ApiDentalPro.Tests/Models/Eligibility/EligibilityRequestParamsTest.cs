using System;
using System.Text.Json;
using ApiDentalPro.Core;
using ApiDentalPro.Models.Eligibility;

namespace ApiDentalPro.Tests.Models.Eligibility;

public class EligibilityRequestParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EligibilityRequestParams
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
            Version = "v2",
            Dependent = new()
            {
                Dob = "dob",
                FirstName = "first_name",
                GroupNumber = "group_number",
                LastName = "last_name",
                MemberID = "member_id",
            },
        };

        EligibilityRequestParamsPayer expectedPayer = new("52133");
        Provider expectedProvider = new() { Npi = "1447364856", TaxID = "270872579" };
        Subscriber expectedSubscriber = new()
        {
            Dob = "01/15/1990",
            FirstName = "John",
            GroupNumber = "GRP001",
            LastName = "Smith",
            MemberID = "123456789",
        };
        string expectedVersion = "v2";
        Dependent expectedDependent = new()
        {
            Dob = "dob",
            FirstName = "first_name",
            GroupNumber = "group_number",
            LastName = "last_name",
            MemberID = "member_id",
        };

        Assert.Equal(expectedPayer, parameters.Payer);
        Assert.Equal(expectedProvider, parameters.Provider);
        Assert.Equal(expectedSubscriber, parameters.Subscriber);
        Assert.Equal(expectedVersion, parameters.Version);
        Assert.Equal(expectedDependent, parameters.Dependent);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EligibilityRequestParams
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
            Version = "v2",
        };

        Assert.Null(parameters.Dependent);
        Assert.False(parameters.RawBodyData.ContainsKey("dependent"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EligibilityRequestParams
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
            Version = "v2",

            // Null should be interpreted as omitted for these properties
            Dependent = null,
        };

        Assert.Null(parameters.Dependent);
        Assert.False(parameters.RawBodyData.ContainsKey("dependent"));
    }

    [Fact]
    public void Url_Works()
    {
        EligibilityRequestParams parameters = new()
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
            Version = "v2",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://wg.api.dental/rest/Eligibility"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EligibilityRequestParams
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
            Version = "v2",
            Dependent = new()
            {
                Dob = "dob",
                FirstName = "first_name",
                GroupNumber = "group_number",
                LastName = "last_name",
                MemberID = "member_id",
            },
        };

        EligibilityRequestParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class EligibilityRequestParamsPayerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EligibilityRequestParamsPayer { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, model.ID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EligibilityRequestParamsPayer { ID = "id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EligibilityRequestParamsPayer>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EligibilityRequestParamsPayer { ID = "id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EligibilityRequestParamsPayer>(
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
        var model = new EligibilityRequestParamsPayer { ID = "id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EligibilityRequestParamsPayer { ID = "id" };

        EligibilityRequestParamsPayer copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProviderTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Provider { Npi = "npi", TaxID = "tax_id" };

        string expectedNpi = "npi";
        string expectedTaxID = "tax_id";

        Assert.Equal(expectedNpi, model.Npi);
        Assert.Equal(expectedTaxID, model.TaxID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Provider { Npi = "npi", TaxID = "tax_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Provider>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Provider { Npi = "npi", TaxID = "tax_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Provider>(
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
        var model = new Provider { Npi = "npi", TaxID = "tax_id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Provider { Npi = "npi", TaxID = "tax_id" };

        Provider copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriberTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriber
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
        var model = new Subscriber
        {
            Dob = "dob",
            FirstName = "first_name",
            GroupNumber = "group_number",
            LastName = "last_name",
            MemberID = "member_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriber>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriber
        {
            Dob = "dob",
            FirstName = "first_name",
            GroupNumber = "group_number",
            LastName = "last_name",
            MemberID = "member_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriber>(
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
        var model = new Subscriber
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
        var model = new Subscriber
        {
            Dob = "dob",
            FirstName = "first_name",
            GroupNumber = "group_number",
            LastName = "last_name",
            MemberID = "member_id",
        };

        Subscriber copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DependentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Dependent
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
        var model = new Dependent
        {
            Dob = "dob",
            FirstName = "first_name",
            GroupNumber = "group_number",
            LastName = "last_name",
            MemberID = "member_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Dependent>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Dependent
        {
            Dob = "dob",
            FirstName = "first_name",
            GroupNumber = "group_number",
            LastName = "last_name",
            MemberID = "member_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Dependent>(
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
        var model = new Dependent
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
        var model = new Dependent { };

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
        var model = new Dependent { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Dependent
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
        var model = new Dependent
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
        var model = new Dependent
        {
            Dob = "dob",
            FirstName = "first_name",
            GroupNumber = "group_number",
            LastName = "last_name",
            MemberID = "member_id",
        };

        Dependent copied = new(model);

        Assert.Equal(model, copied);
    }
}
