using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ApiDentalPro.Core;
using ApiDentalPro.Exceptions;
using ApiDentalPro.Services;

namespace ApiDentalPro;

/// <inheritdoc/>
public sealed class ApiDentalProClient : IApiDentalProClient
{
    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public string ApiKey
    {
        get { return this._options.ApiKey; }
        init { this._options.ApiKey = value; }
    }

    /// <inheritdoc/>
    public string? SdkSource
    {
        get { return this._options.SdkSource; }
        init { this._options.SdkSource = value; }
    }

    /// <inheritdoc/>
    public string? SdkLang
    {
        get { return this._options.SdkLang; }
        init { this._options.SdkLang = value; }
    }

    readonly Lazy<IApiDentalProClientWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IApiDentalProClientWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    /// <inheritdoc/>
    public IApiDentalProClient WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ApiDentalProClient(modifier(this._options));
    }

    readonly Lazy<IEligibilityService> _eligibility;
    public IEligibilityService Eligibility
    {
        get { return _eligibility.Value; }
    }

    readonly Lazy<IClearCoverageService> _clearCoverage;
    public IClearCoverageService ClearCoverage
    {
        get { return _clearCoverage.Value; }
    }

    readonly Lazy<IPayerService> _payer;
    public IPayerService Payer
    {
        get { return _payer.Value; }
    }

    public void Dispose() => this.HttpClient.Dispose();

    public ApiDentalProClient()
    {
        _options = new();

        _withRawResponse = new(() => new ApiDentalProClientWithRawResponse(this._options));
        _eligibility = new(() => new EligibilityService(this));
        _clearCoverage = new(() => new ClearCoverageService(this));
        _payer = new(() => new PayerService(this));
    }

    public ApiDentalProClient(ClientOptions options)
        : this()
    {
        _options = options;
    }
}

/// <inheritdoc/>
public sealed class ApiDentalProClientWithRawResponse : IApiDentalProClientWithRawResponse
{
#if NET
    static readonly Random Random = Random.Shared;
#else
    static readonly ThreadLocal<Random> _threadLocalRandom = new(() => new Random());

    static Random Random
    {
        get { return _threadLocalRandom.Value!; }
    }
#endif

    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public string ApiKey
    {
        get { return this._options.ApiKey; }
        init { this._options.ApiKey = value; }
    }

    /// <inheritdoc/>
    public string? SdkSource
    {
        get { return this._options.SdkSource; }
        init { this._options.SdkSource = value; }
    }

    /// <inheritdoc/>
    public string? SdkLang
    {
        get { return this._options.SdkLang; }
        init { this._options.SdkLang = value; }
    }

    /// <inheritdoc/>
    public IApiDentalProClientWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ApiDentalProClientWithRawResponse(modifier(this._options));
    }

    readonly Lazy<IEligibilityServiceWithRawResponse> _eligibility;
    public IEligibilityServiceWithRawResponse Eligibility
    {
        get { return _eligibility.Value; }
    }

    readonly Lazy<IClearCoverageServiceWithRawResponse> _clearCoverage;
    public IClearCoverageServiceWithRawResponse ClearCoverage
    {
        get { return _clearCoverage.Value; }
    }

    readonly Lazy<IPayerServiceWithRawResponse> _payer;
    public IPayerServiceWithRawResponse Payer
    {
        get { return _payer.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        var idempotencyHeaderValue = string.Format("stainless-csharp-retry-{0}", Guid.NewGuid());
        var maxRetries = this.MaxRetries ?? ClientOptions.DefaultMaxRetries;
        var retries = 0;
        while (true)
        {
            HttpResponse? response = null;
            try
            {
                response = await ExecuteOnce(
                        request,
                        retries,
                        idempotencyHeaderValue,
                        cancellationToken
                    )
                    .ConfigureAwait(false);
            }
            catch (Exception e)
            {
                if (++retries > maxRetries || !ShouldRetry(e))
                {
                    throw;
                }
            }

            if (response != null && (++retries > maxRetries || !ShouldRetry(response)))
            {
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }

                try
                {
                    throw ApiDentalProExceptionFactory.CreateApiException(
                        response.StatusCode,
                        await response.ReadAsString(cancellationToken).ConfigureAwait(false)
                    );
                }
                catch (HttpRequestException e)
                {
                    throw new ApiDentalProIOException("I/O Exception", e);
                }
                finally
                {
                    response.Dispose();
                }
            }

            var backoff = ComputeRetryBackoff(retries, response);
            response?.Dispose();
            await Task.Delay(backoff, cancellationToken).ConfigureAwait(false);
        }
    }

    async Task<HttpResponse> ExecuteOnce<T>(
        HttpRequest<T> request,
        int retryCount,
        string idempotencyHeaderValue,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        using HttpRequestMessage requestMessage = new(
            request.Method,
            request.Params.Url(this._options)
        )
        {
            Content = request.Params.BodyContent(),
        };
        request.Params.AddHeadersToRequest(requestMessage, this._options);
        if (!requestMessage.Headers.Contains("x-stainless-retry-count"))
        {
            requestMessage.Headers.Add("x-stainless-retry-count", retryCount.ToString());
        }
        if (!requestMessage.Headers.Contains("X-Idempotency-Key"))
        {
            requestMessage.Headers.Add("X-Idempotency-Key", idempotencyHeaderValue);
        }
        using CancellationTokenSource timeoutCts = new(
            this.Timeout ?? ClientOptions.DefaultTimeout
        );
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(
            timeoutCts.Token,
            cancellationToken
        );
        HttpResponseMessage responseMessage;
        try
        {
            responseMessage = await this
                .HttpClient.SendAsync(
                    requestMessage,
                    HttpCompletionOption.ResponseHeadersRead,
                    cts.Token
                )
                .ConfigureAwait(false);
        }
        catch (HttpRequestException e)
        {
            throw new ApiDentalProIOException("I/O exception", e);
        }
        return new() { RawMessage = responseMessage, CancellationToken = cts.Token };
    }

    static TimeSpan ComputeRetryBackoff(int retries, HttpResponse? response)
    {
        TimeSpan? apiBackoff = ParseRetryAfterMsHeader(response) ?? ParseRetryAfterHeader(response);
        if (
            apiBackoff != null
            && apiBackoff > TimeSpan.Zero
            && apiBackoff < TimeSpan.FromMinutes(1)
        )
        {
            // If the API asks us to wait a certain amount of time (and it's a reasonable amount), then just
            // do what it says.
            return (TimeSpan)apiBackoff;
        }

        // Apply exponential backoff, but not more than the max.
        var backoffSeconds = Math.Min(0.5 * Math.Pow(2.0, retries - 1), 8.0);
        var jitter = 1.0 - 0.25 * Random.NextDouble();
        return TimeSpan.FromSeconds(backoffSeconds * jitter);
    }

    static TimeSpan? ParseRetryAfterMsHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.TryGetHeaderValues("Retry-After-Ms", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterMs))
        {
            return TimeSpan.FromMilliseconds(retryAfterMs);
        }

        return null;
    }

    static TimeSpan? ParseRetryAfterHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.TryGetHeaderValues("Retry-After", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterSeconds))
        {
            return TimeSpan.FromSeconds(retryAfterSeconds);
        }
        else if (DateTimeOffset.TryParse(headerValue, out var retryAfterDate))
        {
            return retryAfterDate - DateTimeOffset.Now;
        }

        return null;
    }

    static bool ShouldRetry(HttpResponse response)
    {
        if (
            response.TryGetHeaderValues("X-Should-Retry", out var headerValues)
            && bool.TryParse(Enumerable.FirstOrDefault(headerValues), out var shouldRetry)
        )
        {
            // If the server explicitly says whether to retry, then we obey.
            return shouldRetry;
        }

        return (int)response.StatusCode switch
        {
            // Retry on request timeouts
            408
            or
            // Retry on lock timeouts
            409
            or
            // Retry on rate limits
            429
            or
            // Retry internal errors
            >= 500 => true,
            _ => false,
        };
    }

    static bool ShouldRetry(Exception e)
    {
        return e is IOException || e is ApiDentalProIOException;
    }

    public void Dispose() => this.HttpClient.Dispose();

    public ApiDentalProClientWithRawResponse()
    {
        _options = new();

        _eligibility = new(() => new EligibilityServiceWithRawResponse(this));
        _clearCoverage = new(() => new ClearCoverageServiceWithRawResponse(this));
        _payer = new(() => new PayerServiceWithRawResponse(this));
    }

    public ApiDentalProClientWithRawResponse(ClientOptions options)
        : this()
    {
        _options = options;
    }
}
