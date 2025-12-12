using System;
using System.Threading.Tasks;

namespace APIDentalPro.Tests.Services;

public class EligibilityServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Request_Works()
    {
        await this.client.Eligibility.Request(
            new()
            {
                Payer = new("id"),
                Provider = new() { Npi = "npi", TaxID = "tax_id" },
                Subscriber = new()
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
                },
                Version = "version",
            },
            TestContext.Current.CancellationToken
        );
    }
}
