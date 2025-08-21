using System.Threading.Tasks;

namespace APIDentalPro.Tests.Services.Payer;

public class PayerServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var payers = await this.client.Payer.List();
        foreach (var item in payers)
        {
            item.Validate();
        }
    }
}
