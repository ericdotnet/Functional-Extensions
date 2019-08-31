using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions
{
    public static partial class AsyncResultExtensionsLeftOperand
    {
        public static async Task<T> OnBoth<T>(this Task<Result> resultTask, Func<Result, T> func)
        {
            Result result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);
            return result.OnBoth(func);
        }

        public static async Task<K> OnBoth<T, K>(this Task<Result<T>> resultTask, Func<Result<T>, K> func)
        {
            Result<T> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);
            return result.OnBoth(func);
        }

        public static async Task<K> OnBoth<T, K, E>(this Task<Result<T, E>> resultTask,
            Func<Result<T, E>, K> func)
        {
            Result<T, E> result = await resultTask.ConfigureAwait(Result.DefaultConfigureAwait);
            return result.OnBoth(func);
        }
    }
}
