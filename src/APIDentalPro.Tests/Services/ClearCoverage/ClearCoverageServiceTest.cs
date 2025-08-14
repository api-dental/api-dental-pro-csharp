using System;
using System.Threading.Tasks;

namespace APIDentalPro.Tests.Services.ClearCoverage;

public class ClearCoverageServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Request_Works()
    {
        var response = await this.client.ClearCoverage.Request(
            new()
            {
                Payer = new("id"),
                Provider = new() { Npi = "npi", TaxID = "tax_id" },
                Subscriber = new()
                {
                    Dob = DateOnly.Parse("2019-12-27"),
                    FirstName = "first_name",
                    GroupNumber = "group_number",
                    LastName = "last_name",
                    MemberID = "member_id",
                },
                Version = "version",
            }
        );
        _ = response;
    }
}
