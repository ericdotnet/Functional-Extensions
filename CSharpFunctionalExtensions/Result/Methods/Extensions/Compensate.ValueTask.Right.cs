#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static ValueTask<Result> Compensate(this Result result, Func<string, ValueTask<Result>> func)
        {
            if (result.IsSuccess)
            {
                return Result.Success().AsCompletedValueTask();
            }

            return func(result.Error);
        }

        public static ValueTask<UnitResult<E>> Compensate<E>(this Result result, Func<string, ValueTask<UnitResult<E>>> func)
        {
            if (result.IsSuccess)
            {
                return UnitResult.Success<E>().AsCompletedValueTask();
            }

            return func(result.Error);
        }

        public static ValueTask<Result> Compensate<T>(this Result<T> result, Func<string, ValueTask<Result>> func)
        {
            if (result.IsSuccess)
            {
                return Result.Success().AsCompletedValueTask();
            }

            return func(result.Error);
        }

        public static ValueTask<Result<T>> Compensate<T>(this Result<T> result, Func<string, ValueTask<Result<T>>> func)
        {
            if (result.IsSuccess)
            {
                return Result.Success(result.Value).AsCompletedValueTask();
            }

            return func(result.Error);
        }

        public static ValueTask<Result<T, E>> Compensate<T, E>(this Result<T> result, Func<string, ValueTask<Result<T, E>>> func)
        {
            if (result.IsSuccess)
            {
                return Result.Success<T, E>(result.Value).AsCompletedValueTask();
            }

            return func(result.Error);
        }

        public static ValueTask<Result> Compensate<E>(this UnitResult<E> result, Func<E, ValueTask<Result>> func)
        {
            if (result.IsSuccess)
            {
                return Result.Success().AsCompletedValueTask();
            }

            return func(result.Error);
        }

        public static ValueTask<UnitResult<E2>> Compensate<E, E2>(this UnitResult<E> result, Func<E, ValueTask<UnitResult<E2>>> func)
        {
            if (result.IsSuccess)
            {
                return UnitResult.Success<E2>().AsCompletedValueTask();
            }

            return func(result.Error);
        }

        public static ValueTask<Result> Compensate<T, E>(this Result<T, E> result, Func<E, ValueTask<Result>> func)
        {
            if (result.IsSuccess)
            {
                return Result.Success().AsCompletedValueTask();
            }

            return func(result.Error);
        }

        public static ValueTask<UnitResult<E2>> Compensate<T, E, E2>(this Result<T, E> result, Func<E, ValueTask<UnitResult<E2>>> func)
        {
            if (result.IsSuccess)
            {
                return UnitResult.Success<E2>().AsCompletedValueTask();
            }

            return func(result.Error);
        }

        public static ValueTask<Result<T, E2>> Compensate<T, E, E2>(this Result<T, E> result, Func<E, ValueTask<Result<T, E2>>> func)
        {
            if (result.IsSuccess)
            {
                return Result.Success<T, E2>(result.Value).AsCompletedValueTask();
            }

            return func(result.Error);
        }
    }
}
#endif