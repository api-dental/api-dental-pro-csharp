using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using APIDentalPro.Core;
using APIDentalPro.Models.Eligibility;

namespace APIDentalPro.Services;

/// <inheritdoc/>
public sealed class EligibilityService : IEligibilityService
{
    /// <inheritdoc/>
    public IEligibilityService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EligibilityService(this._client.WithOptions(modifier));
    }

    readonly IAPIDentalProClient _client;

    public EligibilityService(IAPIDentalProClient client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<JsonElement> Request(
        EligibilityRequestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EligibilityRequestParams> request = new()
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
