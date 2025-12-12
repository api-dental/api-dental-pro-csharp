using System;
using APIDentalPro;

namespace APIDentalPro.Tests;

public class TestBase
{
    protected IAPIDentalProClient client;

    public TestBase()
    {
        client = new APIDentalProClient()
        {
            BaseUrl =
                Environment.GetEnvironmentVariable("TEST_API_BASE_URL") ?? "http://localhost:4010",
            APIKey = "My API Key",
        };
    }
}
