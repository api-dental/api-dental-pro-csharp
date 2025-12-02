using System.Collections.Generic;
using APIDentalPro.Models.Payer;

namespace APIDentalPro.Tests.Models.Payer;

public class PayerListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PayerListResponse
        {
            ID = "id",
            AltPayerIDs = ["string"],
            Features = ["string"],
            Name = "name",
            OnederfulPayerID = "onederfulPayerId",
            Status = "status",
        };

        string expectedID = "id";
        List<string> expectedAltPayerIDs = ["string"];
        List<string> expectedFeatures = ["string"];
        string expectedName = "name";
        string expectedOnederfulPayerID = "onederfulPayerId";
        string expectedStatus = "status";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAltPayerIDs.Count, model.AltPayerIDs.Count);
        for (int i = 0; i < expectedAltPayerIDs.Count; i++)
        {
            Assert.Equal(expectedAltPayerIDs[i], model.AltPayerIDs[i]);
        }
        Assert.Equal(expectedFeatures.Count, model.Features.Count);
        for (int i = 0; i < expectedFeatures.Count; i++)
        {
            Assert.Equal(expectedFeatures[i], model.Features[i]);
        }
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedOnederfulPayerID, model.OnederfulPayerID);
        Assert.Equal(expectedStatus, model.Status);
    }
}
