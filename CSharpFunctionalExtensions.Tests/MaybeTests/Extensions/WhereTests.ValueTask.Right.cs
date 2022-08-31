﻿using System.Threading.Tasks;
using CSharpFunctionalExtensions.ValueTasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class WhereTests_ValueTask_Right : MaybeTestBase
    {
        [Fact]
        public async ValueTask Where_ValueTask_Right_returns_value_if_predicate_returns_true()
        {
            Maybe<T> maybe = T.Value;

            var maybe2 = await maybe.Where(ExpectAndReturn_ValueTask(T.Value, true));

            maybe2.HasValue.Should().BeTrue();
            maybe2.Value.Should().Be(T.Value);
        }

        [Fact]
        public async ValueTask Where_ValueTask_Right_returns_no_value_if_predicate_returns_false()
        {
            Maybe<T> maybe = T.Value;

            var maybe2 = await maybe.Where(ExpectAndReturn_ValueTask(T.Value, false));

            maybe2.HasValue.Should().BeFalse();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async ValueTask Where_ValueTask_Right_returns_no_value_if_initial_maybe_is_null(bool predicateResult)
        {
            Maybe<T> maybe = null;

            var maybe2 = await maybe.Where(ExpectAndReturn_ValueTask(null, predicateResult));

            maybe2.HasValue.Should().BeFalse();
        }
    }
}