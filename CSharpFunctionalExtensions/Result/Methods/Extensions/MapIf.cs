using System;

namespace CSharpFunctionalExtensions
{
    /// <summary>
    ///     Creates a new result from the return value of a given function if the condition is true. If the calling Result is a failure, a new failure result is returned instead.
    /// </summary>
    public static partial class ResultExtensions
    {
        public static Result<T> MapIf<T>(this Result<T> result, bool condition, Func<T, T> func)
        {
            if (!condition)
            {
                return result;
            }

            return result.Map(func);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function if the condition is true. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Result<T, E> MapIf<T, E>(this Result<T, E> result, bool condition, Func<T, T> func)
        {
            if (!condition)
            {
                return result;
            }

            return result.Map(func);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function if the predicate is true. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Result<T> MapIf<T>(this Result<T> result, Func<T, bool> predicate, Func<T, T> func)
        {
            if (!result.IsSuccess || !predicate(result.Value))
            {
                return result;
            }

            return result.Map(func);
        }

        /// <summary>
        ///     Creates a new result from the return value of a given function if the predicate is true. If the calling Result is a failure, a new failure result is returned instead.
        /// </summary>
        public static Result<T, E> MapIf<T, E>(this Result<T, E> result, Func<T, bool> predicate, Func<T, T> func)
        {
            if (!result.IsSuccess || !predicate(result.Value))
            {
                return result;
            }

            return result.Map(func);
        }
    }
}
