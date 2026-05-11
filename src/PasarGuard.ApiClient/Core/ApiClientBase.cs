
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using PasarGuard.ApiClient.Internal;
using PasarGuard.ApiClient.Serialization;

namespace PasarGuard.ApiClient.Core;

public abstract class ApiClientBase
{
    private readonly ILogger logger;

    protected ApiClientBase(HttpClient httpClient, ILogger logger)
    {
        HttpClient = httpClient;
        this.logger = logger;
    }

    protected HttpClient HttpClient { get; }

    protected async Task<ApiResult<T>> SendAsync<T>(HttpMethod method, string url, object? body, RequestBodyKind bodyKind, IReadOnlyDictionary<string, string?>? headers, CancellationToken cancellationToken)
    {
        using var request = CreateRequest(method, url, body, bodyKind, headers);

        try
        {
            using var response = await HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                return await ReadSuccessAsync<T>(response, cancellationToken).ConfigureAwait(false);
            }

            return await ReadFailureAsync<T>(response, method, url, cancellationToken).ConfigureAwait(false);
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            return ApiResult<T>.Failure(ApiErrorFactory.Create(ApiErrorType.Canceled, "The request was canceled."));
        }
        catch (TaskCanceledException exception)
        {
            logger.LogWarning(exception, "HTTP request timed out for {Method} {Url}", method, url);
            return ApiResult<T>.Failure(ApiErrorFactory.Create(ApiErrorType.Timeout, "The request timed out."));
        }
        catch (HttpRequestException exception)
        {
            logger.LogWarning(exception, "HTTP request failed for {Method} {Url}", method, url);
            return ApiResult<T>.Failure(ApiErrorFactory.Create(ApiErrorType.Network, exception.Message));
        }
    }

    protected async Task<ApiResult> SendAsync(HttpMethod method, string url, object? body, RequestBodyKind bodyKind, IReadOnlyDictionary<string, string?>? headers, CancellationToken cancellationToken)
    {
        using var request = CreateRequest(method, url, body, bodyKind, headers);

        try
        {
            using var response = await HttpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                return ApiResult.Success(response.StatusCode);
            }

            return await ReadFailureAsync(response, method, url, cancellationToken).ConfigureAwait(false);
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            return ApiResult.Failure(ApiErrorFactory.Create(ApiErrorType.Canceled, "The request was canceled."));
        }
        catch (TaskCanceledException exception)
        {
            logger.LogWarning(exception, "HTTP request timed out for {Method} {Url}", method, url);
            return ApiResult.Failure(ApiErrorFactory.Create(ApiErrorType.Timeout, "The request timed out."));
        }
        catch (HttpRequestException exception)
        {
            logger.LogWarning(exception, "HTTP request failed for {Method} {Url}", method, url);
            return ApiResult.Failure(ApiErrorFactory.Create(ApiErrorType.Network, exception.Message));
        }
    }

    private static HttpRequestMessage CreateRequest(HttpMethod method, string url, object? body, RequestBodyKind bodyKind, IReadOnlyDictionary<string, string?>? headers)
    {
        var request = new HttpRequestMessage(method, url);

        if (body is not null)
        {
            request.Content = bodyKind switch
            {
                RequestBodyKind.Json => new StringContent(JsonSerializer.Serialize(body, PasarGuardJsonSerializerOptions.Default), Encoding.UTF8, "application/json"),
                RequestBodyKind.FormUrlEncoded => FormUrlEncodedContentFactory.Create(body),
                _ => null
            };
        }

        if (headers is not null)
        {
            foreach (var header in headers)
            {
                if (!string.IsNullOrWhiteSpace(header.Value))
                {
                    request.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }
        }

        return request;
    }

    private async Task<ApiResult<T>> ReadSuccessAsync<T>(HttpResponseMessage response, CancellationToken cancellationToken)
    {
        if (response.Content.Headers.ContentLength == 0)
        {
            return ApiResult<T>.Success(default, response.StatusCode);
        }

        try
        {
            if (typeof(T) == typeof(string))
            {
                var text = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                return ApiResult<T>.Success((T)(object)text, response.StatusCode);
            }

            await using var stream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
            var value = await JsonSerializer.DeserializeAsync<T>(stream, PasarGuardJsonSerializerOptions.Default, cancellationToken).ConfigureAwait(false);
            return ApiResult<T>.Success(value, response.StatusCode);
        }
        catch (Exception exception) when (exception is JsonException or NotSupportedException)
        {
            logger.LogWarning(exception, "HTTP response could not be deserialized.");
            return ApiResult<T>.Failure(ApiErrorFactory.Create(ApiErrorType.Serialization, exception.Message));
        }
    }

    private async Task<ApiResult<T>> ReadFailureAsync<T>(HttpResponseMessage response, HttpMethod method, string url, CancellationToken cancellationToken)
    {
        var content = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        var error = ApiErrorFactory.Create(response.StatusCode, response.ReasonPhrase ?? string.Empty, content);
        logger.LogWarning("HTTP request returned {StatusCode} for {Method} {Url}", (int)response.StatusCode, method, url);
        return ApiResult<T>.Failure(error);
    }

    private async Task<ApiResult> ReadFailureAsync(HttpResponseMessage response, HttpMethod method, string url, CancellationToken cancellationToken)
    {
        var content = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        var error = ApiErrorFactory.Create(response.StatusCode, response.ReasonPhrase ?? string.Empty, content);
        logger.LogWarning("HTTP request returned {StatusCode} for {Method} {Url}", (int)response.StatusCode, method, url);
        return ApiResult.Failure(error);
    }
}
