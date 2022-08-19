﻿using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests.Extensions
{
    public class OnFailureCompensateTests_ValueTask_Left : TestBase
    {
        [Fact]
        public async Task OnFailureCompensate_ValueTask_Left_on_failure_returns_Ok()
        {
            var myResult = Result.Failure(ErrorMessage).AsValueTask();
            var newResult = await myResult.OnFailureCompensate(Result.Success);

            newResult.IsSuccess.Should().Be(true);
        }
        
        [Fact]
        public async Task OnFailureCompensate_ValueTask_Left_func_string_on_failure_returns_Ok()
        {
            var myResult = Result.Failure(ErrorMessage).AsValueTask();
            var newResult = await myResult.OnFailureCompensate(_ => Result.Success());

            newResult.IsSuccess.Should().Be(true);
        }

        [Fact]
        public async Task OnFailureCompensate_ValueTask_Left_T_func_on_generic_failure_returns_Ok()
        {
            var myResult = Result.Failure<T>(ErrorMessage).AsValueTask();
            var newResult = await myResult.OnFailureCompensate(() => Result.Success(T.Value));

            newResult.IsSuccess.Should().BeTrue();
            newResult.Value.Should().Be(T.Value);
        }

        [Fact]
        public async Task OnFailureCompensate_ValueTask_Left_T_func_with_result_on_generic_failure_returns_Ok()
        {
            var myResult = Result.Failure<T>(ErrorMessage).AsValueTask();
            var newResult = await myResult.OnFailureCompensate(_ => Result.Success(T.Value));

            newResult.IsSuccess.Should().BeTrue();
            newResult.Value.Should().Be(T.Value);
        }

        [Fact]
        public async Task OnFailureCompensate_ValueTask_Left_T_E_func_with_error_object_on_generic_failure_returns_Ok()
        {
            var myResult = Result.Failure<T, E>(E.Value).AsValueTask();
            var newResult = await myResult.OnFailureCompensate(_ => Result.Success<T, E>(T.Value));

            newResult.IsSuccess.Should().BeTrue();
            newResult.Value.Should().Be(T.Value);
        }
        
        [Fact]
        public async Task OnFailureCompensate_ValueTask_Left_T_E_func_on_generic_failure_returns_Ok()
        {
            var myResult = Result.Failure<T, E>(E.Value).AsValueTask();
            var newResult = await myResult.OnFailureCompensate(() => Result.Success<T, E>(T.Value));

            newResult.IsSuccess.Should().BeTrue();
            newResult.Value.Should().Be(T.Value);
        }
    }
}