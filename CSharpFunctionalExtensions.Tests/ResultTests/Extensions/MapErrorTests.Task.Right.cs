﻿using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class MapErrorTests_Task_Right : TestBase
    {
        [Fact]
        public async Task MapError_Task_Right_returns_success()
        {
            Result result = Result.Success();
            var invocations = 0;

            Result actual = await result.MapError(error =>
            {
                invocations++;
                return Task.FromResult($"{error} {error}");
            });

            actual.IsSuccess.Should().BeTrue();
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_Task_Right_returns_new_failure()
        {
            Result result = Result.Failure(ErrorMessage);
            var invocations = 0;

            Result actual = await result.MapError(error =>
            {
                invocations++;
                return Task.FromResult($"{error} {error}");
            });

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be($"{ErrorMessage} {ErrorMessage}");
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_Task_Right_returns_UnitResult_success()
        {
            Result result = Result.Success();
            var invocations = 0;

            UnitResult<E> actual = await result.MapError(error =>
            {
                invocations++;
                return Task.FromResult(E.Value);
            });

            actual.IsSuccess.Should().BeTrue();
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_Task_Right_returns_new_UnitResult_failure()
        {
            Result result = Result.Failure(ErrorMessage);
            var invocations = 0;

            UnitResult<E> actual = await result.MapError(error =>
            {
                invocations++;
                return Task.FromResult(E.Value);
            });

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E.Value);
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_Task_Right_T_returns_success()
        {
            Result<T> result = Result.Success(T.Value);
            var invocations = 0;

            Result<T> actual = await result.MapError(error =>
            {
                invocations++;
                return Task.FromResult($"{error} {error}");
            });

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(T.Value);
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_Task_Right_T_returns_new_failure()
        {
            Result<T> result = Result.Failure<T>(ErrorMessage);
            var invocations = 0;

            Result<T> actual = await result.MapError(error =>
            {
                invocations++;
                return Task.FromResult($"{error} {error}");
            });

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be($"{ErrorMessage} {ErrorMessage}");
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_Task_Right_UnitResult_returns_success()
        {
            UnitResult<E> result = UnitResult.Success<E>();
            var invocations = 0;

            Result actual = await result.MapError(error =>
            {
                invocations++;
                return Task.FromResult($"{error} {error}");
            });

            actual.IsSuccess.Should().BeTrue();
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_Task_Right_UnitResult_returns_new_failure()
        {
            UnitResult<E> result = UnitResult.Failure(E.Value);
            var invocations = 0;

            Result actual = await result.MapError(error =>
            {
                error.Should().Be(E.Value);

                invocations++;
                return Task.FromResult("error");
            });

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be("error");
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_Task_Right_E_UnitResult_returns_success()
        {
            UnitResult<E> result = UnitResult.Success<E>();
            var invocations = 0;

            UnitResult<E2> actual = await result.MapError(error =>
            {
                invocations++;
                return Task.FromResult(E2.Value);
            });

            actual.IsSuccess.Should().BeTrue();
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_Task_Right_E_UnitResult_returns_new_failure()
        {
            UnitResult<E> result = UnitResult.Failure(E.Value);
            var invocations = 0;

            UnitResult<E2> actual = await result.MapError(error =>
            {
                error.Should().Be(E.Value);

                invocations++;
                return Task.FromResult(E2.Value);
            });

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E2.Value);
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_Task_Right_T_E_returns_success()
        {
            Result<T> result = Result.Success(T.Value);
            var invocations = 0;

            Result<T, E> actual = await result.MapError(_ =>
            {
                invocations++;
                return Task.FromResult(E.Value);
            });

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(T.Value);
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_Task_Right_T_E_returns_new_failure()
        {
            Result<T> result = Result.Failure<T>(ErrorMessage);
            var invocations = 0;
            
            Result<T, E> actual = await result.MapError(error =>
            {
                error.Should().Be(ErrorMessage);

                invocations++;
                return Task.FromResult(E.Value);
            });

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E.Value);
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_Task_Right_T_E_string_returns_success()
        {
            Result<T, E> result = Result.Success<T, E>(T.Value);
            var invocations = 0;

            Result<T> actual = await result.MapError(_ =>
            {
                invocations++;
                return Task.FromResult("error");
            });

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(T.Value);
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_Task_Right_T_E_E2_returns_success()
        {
            Result<T, E> result = Result.Success<T, E>(T.Value);
            var invocations = 0;

            Result<T, E2> actual = await result.MapError(_ =>
            {
                invocations++;
                return Task.FromResult(E2.Value);
            });

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(T.Value);
            invocations.Should().Be(0);
        }

        [Fact]
        public async Task MapError_Task_Right_T_E_string_returns_new_failure()
        {
            Result<T, E> result = Result.Failure<T, E>(E.Value);
            var invocations = 0;

            Result<T> actual = await result.MapError(error =>
            {
                error.Should().Be(E.Value);

                invocations++;
                return Task.FromResult("error");
            });

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be("error");
            invocations.Should().Be(1);
        }

        [Fact]
        public async Task MapError_Task_Right_T_E_E2_returns_new_failure()
        {
            Result<T, E> result = Result.Failure<T, E>(E.Value);
            var invocations = 0;

            Result<T, E2> actual = await result.MapError(error =>
            {
                error.Should().Be(E.Value);

                invocations++;
                return Task.FromResult(E2.Value);
            });

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E2.Value);
            invocations.Should().Be(1);
        }
    }
}