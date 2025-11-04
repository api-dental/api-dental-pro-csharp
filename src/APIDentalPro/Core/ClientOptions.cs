using System;
using System.Net.Http;
using APIDentalPro.Exceptions;

namespace APIDentalPro.Core;

public struct ClientOptions()
{
    public HttpClient HttpClient { get; set; } = new();

    Lazy<Uri> _baseUrl = new(() =>
        new Uri(
            Environment.GetEnvironmentVariable("API_DENTAL_PRO_BASE_URL")
                ?? "https://wg.api.dental/rest"
        )
    );
    public Uri BaseUrl
    {
        readonly get { return _baseUrl.Value; }
        set { _baseUrl = new(() => value); }
    }

    public bool ResponseValidation { get; set; } = false;

    public TimeSpan Timeout { get; set; } = TimeSpan.FromMinutes(1);

    Lazy<string> _apiKey = new(() =>
        Environment.GetEnvironmentVariable("API_DENTAL_API_KEY")
        ?? throw new APIDentalProInvalidDataException(
            string.Format("{0} cannot be null", nameof(APIKey)),
            new ArgumentNullException(nameof(APIKey))
        )
    );
    public string APIKey
    {
        readonly get { return _apiKey.Value; }
        set { _apiKey = new(() => value); }
    }

    public string? SDKSource { get; set; } = "api-dental-sdk";

    public string? SDKLang { get; set; } = "";
}
