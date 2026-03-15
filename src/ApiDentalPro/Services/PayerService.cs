using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ApiDentalPro.Core;
using ApiDentalPro.Models.Payer;

namespace ApiDentalPro.Services;

/// <inheritdoc/>
public sealed class PayerService : IPayerService
{
    readonly Lazy<IPayerServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPayerServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IApiDentalProClient _client;

    /// <inheritdoc/>
    public IPayerService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PayerService(this._client.WithOptions(modifier));
    }

    public PayerService(IApiDentalProClient client)
    {
        _client = client;

        _withRawResponse = new(() => new PayerServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<PayerListResponse> List(
        PayerListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class PayerServiceWithRawResponse : IPayerServiceWithRawResponse
{
    readonly IApiDentalProClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPayerServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PayerServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PayerServiceWithRawResponse(IApiDentalProClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PayerListResponse>> List(
        PayerListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PayerListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var payers = await response
                    .Deserialize<PayerListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    payers.Validate();
                }
                return payers;
            }
        );
    }
}
