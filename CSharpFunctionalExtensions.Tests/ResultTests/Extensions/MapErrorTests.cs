﻿using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class MapErrorTests : TestBase
    {
        [Fact]
        public void MapError_returns_success()
        {
            Result result = Result.Success();
            var invocations = 0;

            Result actual = result.MapError(error =>
            {
                invocations++;
                return $"{error} {error}";
            });

            actual.IsSuccess.Should().BeTrue();
            invocations.Should().Be(0);
        }

        [Fact]
        public void MapError_returns_new_failure()
        {
            Result result = Result.Failure(ErrorMessage);
            var invocations = 0;

            Result actual = result.MapError(error =>
            {
                invocations++;
                return $"{error} {error}";
            });

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be($"{ErrorMessage} {ErrorMessage}");
            invocations.Should().Be(1);
        }

        [Fact]
        public void MapError_T_returns_success()
        {
            Result<T> result = Result.Success(T.Value);
            var invocations = 0;

            Result<T> actual = result.MapError(error =>
            {
                invocations++;
                return $"{error} {error}";
            });

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(T.Value);
            invocations.Should().Be(0);
        }

        [Fact]
        public void MapError_T_returns_new_failure()
        {
            Result<T> result = Result.Failure<T>(ErrorMessage);
            var invocations = 0;

            Result<T> actual = result.MapError(error =>
            {
                invocations++;
                return $"{error} {error}";
            });

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be($"{ErrorMessage} {ErrorMessage}");
            invocations.Should().Be(1);
        }

        [Fact]
        public void MapError_T_E_returns_success()
        {
            Result<T> result = Result.Success(T.Value);
            var invocations = 0;

            Result<T, E> actual = result.MapError(_ =>
            {
                invocations++;
                return E.Value;
            });

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(T.Value);
            invocations.Should().Be(0);
        }

        [Fact]
        public void MapError_T_E_returns_new_failure()
        {
            Result<T> result = Result.Failure<T>(ErrorMessage);
            var invocations = 0;
            
            Result<T, E> actual = result.MapError(error =>
            {
                error.Should().Be(ErrorMessage);

                invocations++;
                return E.Value;
            });

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E.Value);
            invocations.Should().Be(1);
        }

        [Fact]
        public void MapError_T_E_E2_returns_success()
        {
            Result<T, E> result = Result.Success<T, E>(T.Value);
            var invocations = 0;

            Result<T, E2> actual = result.MapError(_ =>
            {
                invocations++;
                return E2.Value;
            });

            actual.IsSuccess.Should().BeTrue();
            actual.Value.Should().Be(T.Value);
            invocations.Should().Be(0);
        }

        [Fact]
        public void MapError_T_E_E2_returns_new_failure()
        {
            Result<T, E> result = Result.Failure<T, E>(E.Value);
            var invocations = 0;

            Result<T, E2> actual = result.MapError(error =>
            {
                error.Should().Be(E.Value);

                invocations++;
                return E2.Value;
            });

            actual.IsSuccess.Should().BeFalse();
            actual.Error.Should().Be(E2.Value);
            invocations.Should().Be(1);
        }
    }
}