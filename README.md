# API Dental Pro C# API Library

> [!NOTE]
> The API Dental Pro C# API Library is currently in **beta** and we're excited for you to experiment with it!
>
> This library has not yet been exhaustively tested in production environments and may be missing some features you'd expect in a stable release. As we continue development, there may be breaking changes that require updates to your code.
>
> **We'd love your feedback!** Please share any suggestions, bug reports, feature requests, or general thoughts by [filing an issue](https://www.github.com/api-dental/api-dental-pro-csharp/issues/new).

The API Dental Pro C# SDK provides convenient access to the [API Dental Pro REST API](https://api.dental/docs) from applications written in C#.

It is generated with [Stainless](https://www.stainless.com/).

The REST API documentation can be found on [api.dental](https://api.dental/docs).

## Installation

```bash
dotnet add package APIDentalPro
```

## Requirements

This library requires .NET 8 or later.

> [!NOTE]
> The library is currently in **beta**. The requirements will be lowered in the future.

## Usage

See the [`examples`](examples) directory for complete and runnable examples.

```csharp
using System;
using APIDentalPro;
using APIDentalPro.Models.Eligibility;

// Configured using the API_DENTAL_API_KEY and API_DENTAL_PRO_BASE_URL environment variables
APIDentalProClient client = new();

EligibilityRequestParams parameters = new()
{
    Payer = new("12345"),
    Provider = new()
    {
        Npi = "1234567890",
        TaxID = "123456789",
    },
    Subscriber = new()
    {
        Dob = DateOnly.Parse("2019-12-27"),
        FirstName = "Jane",
        GroupNumber = "22000-00000",
        LastName = "Doe",
        MemberID = "118885555000",
    },
    Version = "v2",
};

var response = await client.Eligibility.Request(parameters);

Console.WriteLine(response);
```

## Client Configuration

Configure the client using environment variables:

```csharp
using APIDentalPro;

// Configured using the API_DENTAL_API_KEY and API_DENTAL_PRO_BASE_URL environment variables
APIDentalProClient client = new();
```

Or manually:

```csharp
using APIDentalPro;

APIDentalProClient client = new() { APIKey = "My API Key" };
```

Or using a combination of the two approaches.

See this table for the available options:

| Property  | Environment variable      | Required | Default value                  |
| --------- | ------------------------- | -------- | ------------------------------ |
| `APIKey`  | `API_DENTAL_API_KEY`      | true     | -                              |
| `BaseUrl` | `API_DENTAL_PRO_BASE_URL` | true     | `"https://wg.api.dental/rest"` |

## Requests and responses

To send a request to the API Dental Pro API, build an instance of some `Params` class and pass it to the corresponding client method. When the response is received, it will be deserialized into an instance of a C# class.

For example, `client.Eligibility.Request` should be called with an instance of `EligibilityRequestParams`, and it will return an instance of `Task<JsonElement>`.

## Error handling

The SDK throws custom unchecked exception types:

- `APIDentalProApiException`: Base class for API errors. See this table for which exception subclass is thrown for each HTTP status code:

| Status | Exception                                   |
| ------ | ------------------------------------------- |
| 400    | `APIDentalProBadRequestException`           |
| 401    | `APIDentalProUnauthorizedException`         |
| 403    | `APIDentalProForbiddenException`            |
| 404    | `APIDentalProNotFoundException`             |
| 422    | `APIDentalProUnprocessableEntityException`  |
| 429    | `APIDentalProRateLimitException`            |
| 5xx    | `APIDentalPro5xxException`                  |
| others | `APIDentalProUnexpectedStatusCodeException` |

Additionally, all 4xx errors inherit from `APIDentalPro4xxException`.

false

- `APIDentalProIOException`: I/O networking errors.

- `APIDentalProInvalidDataException`: Failure to interpret successfully parsed data. For example, when accessing a property that's supposed to be required, but the API unexpectedly omitted it from the response.

- `APIDentalProException`: Base class for all exceptions.

## Semantic versioning

This package generally follows [SemVer](https://semver.org/spec/v2.0.0.html) conventions, though certain backwards-incompatible changes may be released as minor versions:

1. Changes to library internals which are technically public but not intended or documented for external use. _(Please open a GitHub issue to let us know if you are relying on such internals.)_
2. Changes that we do not expect to impact the vast majority of users in practice.

We take backwards-compatibility seriously and work hard to ensure you can rely on a smooth upgrade experience.

We are keen for your feedback; please open an [issue](https://www.github.com/api-dental/api-dental-pro-csharp/issues) with questions, bugs, or suggestions.
