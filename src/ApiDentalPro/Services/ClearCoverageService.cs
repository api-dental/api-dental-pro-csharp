using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using ApiDentalPro.Core;
using ApiDentalPro.Models.ClearCoverage;

namespace ApiDentalPro.Services;

/// <inheritdoc/>
public sealed class ClearCoverageService : IClearCoverageService
{
    readonly Lazy<IClearCoverageServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IClearCoverageServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IApiDentalProClient _client;

    /// <inheritdoc/>
    public IClearCoverageService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ClearCoverageService(this._client.WithOptions(modifier));
    }

    public ClearCoverageService(IApiDentalProClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new ClearCoverageServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<JsonElement> Request(
        ClearCoverageRequestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Request(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ClearCoverageServiceWithRawResponse : IClearCoverageServiceWithRawResponse
{
    readonly IApiDentalProClientWithRawResponse _client;

    /// <inheritdoc/>
    public IClearCoverageServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ClearCoverageServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ClearCoverageServiceWithRawResponse(IApiDentalProClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JsonElement>> Request(
        ClearCoverageRequestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ClearCoverageRequestParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                return await response.Deserialize<JsonElement>(token).ConfigureAwait(false);
            }
        );
    }
}
