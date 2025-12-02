using System;
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
}
