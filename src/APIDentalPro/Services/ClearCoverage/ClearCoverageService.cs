using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using APIDentalPro.Core;
using APIDentalPro.Models.ClearCoverage;

namespace APIDentalPro.Services.ClearCoverage;

public sealed class ClearCoverageService : IClearCoverageService
{
    public IClearCoverageService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ClearCoverageService(this._client.WithOptions(modifier));
    }

    readonly IAPIDentalProClient _client;

    public ClearCoverageService(IAPIDentalProClient client)
    {
        _client = client;
    }

    public async Task<JsonElement> Request(
        ClearCoverageRequestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ClearCoverageRequestParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        using var response = await this
            ._client.Execute(request, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize<JsonElement>(cancellationToken).ConfigureAwait(false);
    }
}
