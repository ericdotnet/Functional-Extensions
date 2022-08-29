﻿using System.Threading.Tasks;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class BindTryTests_Task_Left : BindTryTestsBase
    {
        #region BindTry for Task<Result> with function returning Result
        [Fact]
        public async Task BindTry_execute_func_returning_success_on_task_success_returns_success()
        {
            Task<Result> sut = Result.Success().AsTask();

            Result result = await sut.BindTry(Success);

            AssertSuccess(result);
        }

        [Fact]
        public async Task BindTry_execute_func_returning_success_on_task_failure_returns_failure()
        {
            Task<Result> sut = Result.Failure(ErrorMessage).AsTask();

            Result result = await sut.BindTry(Success);

            AssertFailure(result);
        }

        [Fact]
        public async Task BindTry_execute_func_returning_failure_on_task_success_returns_failure()
        {
            Task<Result> sut = Result.Success().AsTask();

            Result result = await sut.BindTry(Failure);

            AssertFailure(result);
        }

        [Fact]
        public async Task BindTry_execute_throwing_func_on_taks_success_returns_failure_with_exception_message()
        {
            Task<Result> sut = Result.Success().AsTask();

            Result result = await sut.BindTry(Throwing);

            AssertFailure(result);
        }

        [Fact]
        public async Task BindTry_execute_throwing_func_on_task_success_with_custom_error_handler_returns_failure_with_custom_message()
        {
            Task<Result> sut = Result.Success().AsTask();

            Result result = await sut.BindTry(Throwing, e => ErrorMessage2);

            AssertFailure(result, ErrorMessage2);
        }
        #endregion

        #region BindTry for Task<Result> with function returning Result<K>
        [Fact]
        public async Task BindTry_execute_func_returning_success_K_on_task_success_returns_success()
        {
            Task<Result> sut = Result.Success().AsTask();

            Result<K> result = await sut.BindTry(Success_K);

            AssertSuccess(result);
        }

        [Fact]
        public async Task BindTry_execute_func_returning_success_K_on_task_failure_returns_failure()
        {
            Task<Result> sut = Result.Failure(ErrorMessage).AsTask();

            Result<K> result = await sut.BindTry(Success_K);

            AssertFailure(result);
        }

        [Fact]
        public async Task BindTry_execute_func_returning_failure_K_on_task_success_returns_failure()
        {
            Task<Result> sut = Result.Success().AsTask();

            Result<K> result = await sut.BindTry(Failure_K);

            AssertFailure(result);
        }

        [Fact]
        public async Task BindTry_execute_throwing_func_K_on_taks_success_returns_failure_with_exception_message()
        {
            Task<Result> sut = Result.Success().AsTask();

            Result<K> result = await sut.BindTry(Throwing_K);

            AssertFailure(result);
        }

        [Fact]
        public async Task BindTry_execute_throwing_func_K_on_success_with_custom_error_handler_returns_failure_with_custom_message()
        {
            Task<Result> sut = Result.Success().AsTask();

            Result<K> result = await sut.BindTry(Throwing_K, e => ErrorMessage2);

            AssertFailure(result, ErrorMessage2);
        }
        #endregion

        #region BindTry for Task<Result<T>> with function returning Result
        [Fact]
        public async Task BindTry_execute_func_returning_success_on_task_success_T_returns_success()
        {
            Task<Result<T>> sut = Result.Success(T.Value).AsTask();

            Result result = await sut.BindTry(t => Success());

            AssertSuccess(result);
        }

        [Fact]
        public async Task BindTry_execute_task_func_returning_success_T_on_task_failure_returns_failure()
        {
            Task<Result<T>> sut = Result.Failure<T>(ErrorMessage).AsTask();

            Result result = await sut.BindTry(t => Success());

            AssertFailure(result);
        }

        [Fact]
        public async Task BindTry_execute_func_returning_failure_on_task_success_T_returns_failure()
        {
            Task<Result<T>> sut = Result.Success(T.Value).AsTask();

            Result result = await sut.BindTry(t => Failure());

            AssertFailure(result);
        }

        [Fact]
        public async Task BindTry_execute_throwing_func_on_taks_success_T_returns_failure_with_exception_message()
        {
            Task<Result<T>> sut = Result.Success(T.Value).AsTask();

            Result result = await sut.BindTry(t => Throwing());

            AssertFailure(result);
        }

        [Fact]
        public async Task BindTry_execute_throwing_func_on_success_T_with_custom_error_handler_returns_failure_with_custom_message()
        {
            Task<Result<T>> sut = Result.Success(T.Value).AsTask();

            Result result = await sut.BindTry(t => Throwing(), e => ErrorMessage2);

            AssertFailure(result, ErrorMessage2);
        }
        #endregion

        #region BindTry for Task<Result<T>> with function returning Result<K>
        [Fact]
        public async Task BindTry_execute_func_returning_success_K_on_task_success_T_returns_success()
        {
            Task<Result<T>> sut = Result.Success(T.Value).AsTask();

            Result<K> result = await sut.BindTry(t => Success_K());

            AssertSuccess(result);
        }

        [Fact]
        public async Task BindTry_execute_func_returning_success_K_on_task_failure_T_returns_failure()
        {
            Task<Result<T>> sut = Result.Failure<T>(ErrorMessage).AsTask();

            Result<K> result = await sut.BindTry(t => Success_K());

            AssertFailure(result);
        }

        [Fact]
        public async Task BindTry_execute_func_returning_failure_K_on_task_success_T_returns_failure()
        {
            Task<Result<T>> sut = Result.Success(T.Value).AsTask();

            Result<K> result = await sut.BindTry(t => Failure_K());

            AssertFailure(result);
        }

        [Fact]
        public async Task BindTry_execute_throwing_func_K_on_taks_success_T_returns_failure_with_exception_message()
        {
            Task<Result<T>> sut = Result.Success(T.Value).AsTask();

            Result<K> result = await sut.BindTry(t => Throwing_K());

            AssertFailure(result);
        }

        [Fact]
        public async Task BindTry_execute_throwing_func_K_on_success_T_with_custom_error_handler_returns_failure_with_custom_message()
        {
            Task<Result<T>> sut = Result.Success(T.Value).AsTask();

            Result<K> result = await sut.BindTry(t => Throwing_K(), e => ErrorMessage2);

            AssertFailure(result, ErrorMessage2);
        }
        #endregion

        #region BindTry for Task<Result<T,E>> with function returning UnitResult<E>
        [Fact]
        public async Task BindTry_execute_func_returning_success_E_on_task_success_T_E_returns_success()
        {
            Task<Result<T, E>> sut = Result.Success<T, E>(T.Value).AsTask();

            UnitResult<E> result = await sut.BindTry(t => UnitResult_Success_E(), e => E.Value2);

            AssertSuccess(result);
        }

        [Fact]
        public async Task BindTry_execute_func_returning_success_E_on_task_failure_T_E_returns_failure()
        {
            Task<Result<T, E>> sut = Result.Failure<T, E>(E.Value).AsTask();

            UnitResult<E> result = await sut.BindTry(t => UnitResult_Success_E(), e => E.Value2);

            AssertFailure(result);
        }

        [Fact]
        public async Task BindTry_execute_func_returning_failure_E_on_task_success_T_E_returns_failure()
        {
            Task<Result<T, E>> sut = Result.Success<T, E>(T.Value).AsTask();

            UnitResult<E> result = await sut.BindTry(t => UnitResult_Failure_E(), e => E.Value2);

            AssertFailure(result);
        }

        [Fact]
        public async Task BindTry_execute_throwing_func_E_on_success_T_E_returns_failure_with_value_from_error_handler()
        {
            Task<Result<T, E>> sut = Result.Success<T, E>(T.Value).AsTask();

            UnitResult<E> result = await sut.BindTry(t => Throwing_E(), e => E.Value2);

            AssertFailure(result, E.Value2);
        }
        #endregion

        #region BindTry for Task<Result<T,E>> with function returning Result<K,E>
        [Fact]
        public async Task BindTry_execute_func_returning_success_K_E_on_task_success_T_E_returns_success()
        {
            Task<Result<T, E>> sut = Result.Success<T, E>(T.Value).AsTask();

            Result<K, E> result = await sut.BindTry(Success_T_E_Func_K, e => E.Value2);

            AssertSuccess(result);
        }

        [Fact]
        public async Task BindTry_execute_func_returning_success_K_E_on_task_failure_T_E_returns_failure()
        {
            Task<Result<T, E>> sut = Result.Failure<T, E>(E.Value).AsTask();

            Result<K, E> result = await sut.BindTry(Success_T_E_Func_K, e => E.Value2);

            AssertFailure(result);
        }

        [Fact]
        public async Task BindTry_execute_func_returning_failure_K_E_on_task_success_T_E_returns_failure()
        {
            Task<Result<T, E>> sut = Result.Success<T, E>(T.Value).AsTask();

            Result<K, E> result = await sut.BindTry(Failure_T_E_Func_K, e => E.Value2);

            AssertFailure(result);
        }

        [Fact]
        public async Task BindTry_execute_throwing_func_K_E_on_success_T_E_returns_failure_with_value_from_error_handler()
        {
            Task<Result<T, E>> sut = Result.Success<T, E>(T.Value).AsTask();

            Result<K, E> result = await sut.BindTry(t => Throwing_K_E(), e => E.Value2);

            AssertFailure(result, E.Value2);
        }
        #endregion

        #region BindTry for Task<UnitResult<E>> with function returning Result<T,E>
        [Fact]
        public async Task BindTry_execute_func_returning_success_T_E_on_task_success_E_returns_success()
        {
            Task<UnitResult<E>> sut = UnitResult.Success<E>().AsTask();

            Result<T, E> result = await sut.BindTry(Success_T_E, e => E.Value2);

            AssertSuccess(result);
        }

        [Fact]
        public async Task BindTry_execute_func_returning_success_T_E_on_task_failure_E_returns_failure()
        {
            Task<UnitResult<E>> sut = UnitResult.Failure(E.Value).AsTask();

            Result<T, E> result = await sut.BindTry(Success_T_E, e => E.Value2);

            AssertFailure(result);
        }

        [Fact]
        public async Task BindTry_execute_func_returning_failure_T_E_on_task_success_E_returns_failure()
        {
            Task<UnitResult<E>> sut = UnitResult.Success<E>().AsTask();

            Result<T, E> result = await sut.BindTry(Failure_T_E, e => E.Value2);

            AssertFailure(result);
        }

        [Fact]
        public async Task BindTry_execute_throwing_func_T_E_on_success_E_returns_failure_with_value_from_error_handler()
        {
            Task<UnitResult<E>> sut = UnitResult.Success<E>().AsTask();

            Result<T, E> result = await sut.BindTry(Throwing_T_E, e => E.Value2);

            AssertFailure(result, E.Value2);
        }
        #endregion

        #region BindTry for Task<UnitResult<E>> with function returning UnitResult<E>
        [Fact]
        public async Task BindTry_execute_func_returning_success_E_on_task_success_E_returns_success()
        {
            Task<UnitResult<E>> sut = UnitResult.Success<E>().AsTask();

            UnitResult<E> result = await sut.BindTry(UnitResult_Success_E, e => E.Value2);

            AssertSuccess(result);
        }

        [Fact]
        public async Task BindTry_execute_func_returning_success_E_on_task_failure_E_returns_failure()
        {
            Task<UnitResult<E>> sut = UnitResult.Failure(E.Value).AsTask();

            UnitResult<E> result = await sut.BindTry(UnitResult_Success_E, e => E.Value2);

            AssertFailure(result);
        }

        [Fact]
        public async Task BindTry_execute_func_returning_failure_E_on_task_success_E_returns_failure()
        {
            Task<UnitResult<E>> sut = UnitResult.Success<E>().AsTask();

            UnitResult<E> result = await sut.BindTry(UnitResult_Failure_E, e => E.Value2);

            AssertFailure(result);
        }

        [Fact]
        public async Task BindTry_execute_throwing_func_E_on_success_E_returns_failure_with_value_from_error_handler()
        {
            Task<UnitResult<E>> sut = UnitResult.Success<E>().AsTask();

            UnitResult<E> result = await sut.BindTry(Throwing_E, e => E.Value2);

            AssertFailure(result, E.Value2);
        }
        #endregion
    }
}
