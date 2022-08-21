#if NET5_0_OR_GREATER
using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class ResultExtensions
    {
        public static async ValueTask<Result> BindIf(this ValueTask<Result> resultTask, bool condition, Func<Result> func)
        {
            var result = await resultTask;
            return result.BindIf(condition, func);
        }

        public static async ValueTask<Result<T>> BindIf<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, Result<T>> func)
        {
            var result = await resultTask;
            return result.BindIf(condition, func);
        }

        public static async ValueTask<UnitResult<E>> BindIf<E>(this ValueTask<UnitResult<E>> resultTask, bool condition, Func<UnitResult<E>> func)
        {
            var result = await resultTask;
            return result.BindIf(condition, func);
        }

        public static async ValueTask<Result<T, E>> BindIf<T, E>(this ValueTask<Result<T, E>> resultTask, bool condition, Func<T, Result<T, E>> func)
        {
            var result = await resultTask;
            return result.BindIf(condition, func);
        }

        public static async ValueTask<Result> BindIf(this ValueTask<Result> resultTask, Func<bool> predicate, Func<Result> func)
        {
            var result = await resultTask;
            return result.BindIf(predicate, func);
        }

        public static async ValueTask<Result<T>> BindIf<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Result<T>> func)
        {
            var result = await resultTask;
            return result.BindIf(predicate, func);
        }

        public static async ValueTask<UnitResult<E>> BindIf<E>(this ValueTask<UnitResult<E>> resultTask, Func<bool> predicate, Func<UnitResult<E>> func)
        {
            var result = await resultTask;
            return result.BindIf(predicate, func);
        }

        public static async ValueTask<Result<T, E>> BindIf<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, bool> predicate, Func<T, Result<T, E>> func)
        {
            var result = await resultTask;
            return result.BindIf(predicate, func);
        }
    }
}
#endif