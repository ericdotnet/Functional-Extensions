﻿#nullable enable
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.Json.Serialization
{
    public static class HttpResponseMessageJsonExtensions
    {
        public static async Task<Result> ReadResultAsync(this HttpResponseMessage response, bool ensureSuccessStatusCode = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (response is null)
            {
                return Result.Failure(DtoMessages.HttpResponseMessageIsNull);
            }

            if (ensureSuccessStatusCode && !response.IsSuccessStatusCode)
            {
                return Result.Failure(DtoMessages.NotSuccsessStatusCodeFormat(response.StatusCode, await response.Content.ReadAsStringAsync()));
            }

            return await
            Result.Try(() => response.Content.ReadFromJsonAsync<Result>(CSharpFunctionalExtensionsJsonSerializerOptions.Options, cancellationToken), ex => DtoMessages.ContentJsonNotResult)
                  .Bind(result => result);
        }

        public static async Task<Result<T>> ReadResultAsync<T>(this HttpResponseMessage response, bool ensureSuccessStatusCode = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (response is null)
            {
                return Result.Failure<T>(DtoMessages.HttpResponseMessageIsNull);
            }

            if (ensureSuccessStatusCode && !response.IsSuccessStatusCode)
            {
                return Result.Failure<T>(DtoMessages.NotSuccsessStatusCodeFormat(response.StatusCode, await response.Content.ReadAsStringAsync()));
            }

            return await
            Result.Try(() => response.Content.ReadFromJsonAsync<Result<T>>(CSharpFunctionalExtensionsJsonSerializerOptions.Options, cancellationToken), ex => DtoMessages.ContentJsonNotResult)
                  .Bind(result => result);
        }

        public static async Task<UnitResult<E>> ReadUnitResultAsync<E>(this HttpResponseMessage? response, bool ensureSuccessStatusCode = true, CancellationToken cancellationToken = default(CancellationToken))
            where E : new()
        {
            if (response is null)
            {
                return UnitResult.Failure<E>(new());
            }

            if (ensureSuccessStatusCode && !response.IsSuccessStatusCode)
            {
                return UnitResult.Failure<E>(new());
            }

            try
            {
                return await response.Content.ReadFromJsonAsync<UnitResult<E>>(CSharpFunctionalExtensionsJsonSerializerOptions.Options, cancellationToken);
            }
            catch (JsonException)
            {
                return UnitResult.Failure<E>(new());
            }
        }
    }
}
