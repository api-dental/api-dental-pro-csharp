using System;
using System.Text.Json;
using APIDentalPro.Models.ClearCoverage;

namespace APIDentalPro.Tests.Models.ClearCoverage;

public class PayerModelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PayerModel { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, model.ID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PayerModel { ID = "id" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PayerModel>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PayerModel { ID = "id" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PayerModel>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";

        Assert.Equal(expectedID, deserialized.ID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PayerModel { ID = "id" };

        model.Validate();
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Provider>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Provider { Npi = "npi", TaxID = "tax_id" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Provider>(json);
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
}

public class SubscriberTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriber
        {
            Dob =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2019-12-27"),
            FirstName = "first_name",
            GroupNumber = "group_number",
            LastName = "last_name",
            MemberID = "member_id",
        };

#if NET
        DateOnly
#else
        DateTimeOffset
#endif
        expectedDob =
#if NET
        DateOnly
#else
        DateTimeOffset
#endif
        .Parse("2019-12-27");
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
            Dob =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2019-12-27"),
            FirstName = "first_name",
            GroupNumber = "group_number",
            LastName = "last_name",
            MemberID = "member_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Subscriber>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriber
        {
            Dob =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2019-12-27"),
            FirstName = "first_name",
            GroupNumber = "group_number",
            LastName = "last_name",
            MemberID = "member_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Subscriber>(json);
        Assert.NotNull(deserialized);

#if NET
        DateOnly
#else
        DateTimeOffset
#endif
        expectedDob =
#if NET
        DateOnly
#else
        DateTimeOffset
#endif
        .Parse("2019-12-27");
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
            Dob =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2019-12-27"),
            FirstName = "first_name",
            GroupNumber = "group_number",
            LastName = "last_name",
            MemberID = "member_id",
        };

        model.Validate();
    }
}

public class DependentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Dependent
        {
            Dob =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2019-12-27"),
            FirstName = "first_name",
            GroupNumber = "group_number",
            LastName = "last_name",
            MemberID = "member_id",
        };

#if NET
        DateOnly
#else
        DateTimeOffset
#endif
        expectedDob =
#if NET
        DateOnly
#else
        DateTimeOffset
#endif
        .Parse("2019-12-27");
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
            Dob =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2019-12-27"),
            FirstName = "first_name",
            GroupNumber = "group_number",
            LastName = "last_name",
            MemberID = "member_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Dependent>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Dependent
        {
            Dob =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2019-12-27"),
            FirstName = "first_name",
            GroupNumber = "group_number",
            LastName = "last_name",
            MemberID = "member_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Dependent>(json);
        Assert.NotNull(deserialized);

#if NET
        DateOnly
#else
        DateTimeOffset
#endif
        expectedDob =
#if NET
        DateOnly
#else
        DateTimeOffset
#endif
        .Parse("2019-12-27");
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
            Dob =
#if NET
            DateOnly
#else
            DateTimeOffset
#endif
            .Parse("2019-12-27"),
            FirstName = "first_name",
            GroupNumber = "group_number",
            LastName = "last_name",
            MemberID = "member_id",
        };

        model.Validate();
    }
}
