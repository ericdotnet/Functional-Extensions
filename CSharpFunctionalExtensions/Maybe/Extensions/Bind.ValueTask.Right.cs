﻿#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class MaybeExtensions
    {
        public static ValueTask<Maybe<K>> Bind<T, K>(this Maybe<T> maybe, Func<T, ValueTask<Maybe<K>>> selector)
        {
            if (maybe.HasNoValue)
                return Maybe<K>.None.AsCompletedValueTask();

            return selector(maybe.GetValueOrThrow());
        }
    }
}
#endif