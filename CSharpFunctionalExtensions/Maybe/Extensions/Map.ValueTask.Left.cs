﻿#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks
{
    public static partial class MaybeExtensions
    {
        public static async ValueTask<Maybe<K>> Map<T, K>(this ValueTask<Maybe<T>> valueTask, Func<T, K> selector)
        {
            Maybe<T> maybe = await valueTask;
            return maybe.Map(selector);
        }
    }
}
#endif