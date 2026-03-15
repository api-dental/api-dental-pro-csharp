using System.Threading.Tasks;
using ApiDentalPro.Models.ClearCoverage;

namespace ApiDentalPro.Tests.Services;

public class ClearCoverageServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Request_Works()
    {
        var response = await this.client.ClearCoverage.Request(
            new()
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
                Version = Version.V2,
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
