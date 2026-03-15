using System.Threading.Tasks;

namespace ApiDentalPro.Tests.Services;

public class PayerServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var payers = await this.client.Payer.List(new(), TestContext.Current.CancellationToken);
        payers.Validate();
    }
}
