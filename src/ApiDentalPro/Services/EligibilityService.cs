using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ApiDentalPro.Core;
using ApiDentalPro.Models.Eligibility;

namespace ApiDentalPro.Services;

/// <inheritdoc/>
public sealed class EligibilityService : IEligibilityService
{
    readonly Lazy<IEligibilityServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEligibilityServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IApiDentalProClient _client;

    /// <inheritdoc/>
    public IEligibilityService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EligibilityService(this._client.WithOptions(modifier));
    }

    public EligibilityService(IApiDentalProClient client)
    {
        _client = client;

        _withRawResponse = new(() => new EligibilityServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<EligibilityRequestResponse> Request(
        EligibilityRequestParams parameters,
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
public sealed class EligibilityServiceWithRawResponse : IEligibilityServiceWithRawResponse
{
    readonly IApiDentalProClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEligibilityServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new EligibilityServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EligibilityServiceWithRawResponse(IApiDentalProClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EligibilityRequestResponse>> Request(
        EligibilityRequestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EligibilityRequestParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<EligibilityRequestResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }
}
