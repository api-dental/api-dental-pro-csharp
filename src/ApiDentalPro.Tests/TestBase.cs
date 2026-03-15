using System;
using ApiDentalPro;

namespace ApiDentalPro.Tests;

public class TestBase
{
    protected IApiDentalProClient client;

    public TestBase()
    {
        client = new ApiDentalProClient()
        {
            BaseUrl =
                Environment.GetEnvironmentVariable("TEST_API_BASE_URL") ?? "http://localhost:4010",
            ApiKey = "My API Key",
        };
    }
}
