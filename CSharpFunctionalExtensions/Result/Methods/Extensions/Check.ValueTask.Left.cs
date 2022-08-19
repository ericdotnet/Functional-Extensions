#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async ValueTask<Result<T>> Check<T>(this ValueTask<Result<T>> resultTask, Func<T, Result> func)
        {
            Result<T> result = await resultTask;
            return result.Check(func);
        }

        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async ValueTask<Result<T>> Check<T, K>(this ValueTask<Result<T>> resultTask,
            Func<T, Result<K>> func)
        {
            Result<T> result = await resultTask;
            return result.Check(func);
        }

        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async ValueTask<Result<T, E>> Check<T, K, E>(this ValueTask<Result<T, E>> resultTask,
            Func<T, Result<K, E>> func)
        {
            Result<T, E> result = await resultTask;
            return result.Check(func);
        }

        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async ValueTask<Result<T, E>> Check<T, E>(this ValueTask<Result<T, E>> resultTask,
            Func<T, UnitResult<E>> func)
        {
            Result<T, E> result = await resultTask;
            return result.Check(func);
        }

        /// <summary>
        ///     If the calling result is a success, the given function is executed and its Result is checked. If this Result is a failure, it is returned. Otherwise, the calling result is returned.
        /// </summary>
        public static async ValueTask<UnitResult<E>> Check<E>(this ValueTask<UnitResult<E>> resultTask,
            Func<UnitResult<E>> func)
        {
            UnitResult<E> result = await resultTask;
            return result.Check(func);
        }
    }
}
#endif