﻿using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests
{
    public class AsyncExtensionsTests
    {
        [Fact]
        public async Task Async_Left_Where_returns_value_if_predicate_returns_true()
        {
            var instance = new MyClass { Property = "Some value" };
            Task<Maybe<MyClass>> maybeTask = GetMaybeTask(instance);

            Maybe<MyClass> maybe2 = await maybeTask.Where(ExpectAndReturn(instance, true));

            maybe2.HasValue.Should().BeTrue();
            maybe2.Value.Should().Be(instance);
        }

        [Fact]
        public async Task Async_Left_Where_returns_no_value_if_predicate_returns_false()
        {
            var instance = new MyClass { Property = "Some value" };
            Task<Maybe<MyClass>> maybeTask = GetMaybeTask(instance);

            Maybe<MyClass> maybe2 = await maybeTask.Where(ExpectAndReturn(instance, false));

            maybe2.HasValue.Should().BeFalse();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task Async_Left_Where_returns_no_value_if_initial_maybe_is_null(bool predicateResult)
        {
            Task<Maybe<MyClass>> maybeTask = GetMaybeTask(Maybe<MyClass>.None);

            Maybe<MyClass> maybe2 = await maybeTask.Where(ExpectAndReturn(null, predicateResult));

            maybe2.HasValue.Should().BeFalse();
        }

        [Fact]
        public async Task Async_Right_Where_returns_value_if_predicate_returns_true()
        {
            var instance = new MyClass { Property = "Some value" };
            Maybe<MyClass> maybe = instance;

            Maybe<MyClass> maybe2 = await maybe.Where(ExpectAndReturn(instance, true.AsTask()));

            maybe2.HasValue.Should().BeTrue();
            maybe2.Value.Should().Be(instance);
        }

        [Fact]
        public async Task Async_Right_Where_returns_no_value_if_predicate_returns_false()
        {
            var instance = new MyClass { Property = "Some value" };
            Maybe<MyClass> maybe = instance;

            Maybe<MyClass> maybe2 = await maybe.Where(ExpectAndReturn(instance, false.AsTask()));

            maybe2.HasValue.Should().BeFalse();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task Async_Right_Where_returns_no_value_if_initial_maybe_is_null(bool predicateResult)
        {
            Maybe<MyClass> maybe = Maybe<MyClass>.None;

            Maybe<MyClass> maybe2 = await maybe.Where(ExpectAndReturn(null, predicateResult.AsTask()));

            maybe2.HasValue.Should().BeFalse();
        }

        [Fact]
        public async Task Async_Both_Where_returns_value_if_predicate_returns_true()
        {
            var instance = new MyClass { Property = "Some value" };
            Task<Maybe<MyClass>> maybeTask = GetMaybeTask(instance);

            Maybe<MyClass> maybe2 = await maybeTask.Where(ExpectAndReturn(instance, true.AsTask()));

            maybe2.HasValue.Should().BeTrue();
            maybe2.Value.Should().Be(instance);
        }

        [Fact]
        public async Task Async_Both_Where_returns_no_value_if_predicate_returns_false()
        {
            var instance = new MyClass { Property = "Some value" };
            Task<Maybe<MyClass>> maybeTask = GetMaybeTask(instance);

            Maybe<MyClass> maybe2 = await maybeTask.Where(ExpectAndReturn(instance, false.AsTask()));

            maybe2.HasValue.Should().BeFalse();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task Async_Both_Where_returns_no_value_if_initial_maybe_is_null(bool predicateResult)
        {
            Task<Maybe<MyClass>> maybeTask = GetMaybeTask(Maybe<MyClass>.None);

            Maybe<MyClass> maybe2 = await maybeTask.Where(ExpectAndReturn(null, predicateResult.AsTask()));

            maybe2.HasValue.Should().BeFalse();
        }

        [Fact]
        public async Task Async_Left_Map_returns_mapped_value()
        {
            var instance = new MyClass { Property = "Some value" };
            Task<Maybe<MyClass>> maybeTask = GetMaybeTask(instance);
            var result = new MyClass { Property = "Different value" };

            Maybe<MyClass> maybe2 = await maybeTask.Map(ExpectAndReturn(instance, result));

            maybe2.HasValue.Should().BeTrue();
            maybe2.Value.Should().Be(result);
        }

        [Fact]
        public async Task Async_Left_Map_returns_no_value_if_initial_maybe_is_null()
        {
            Task<Maybe<MyClass>> maybeTask = GetMaybeTask(Maybe<MyClass>.None);
            var result = new MyClass { Property = "Different value" };
            
            Maybe<MyClass> maybe2 = await maybeTask.Map(ExpectAndReturn(null, result));

            maybe2.HasValue.Should().BeFalse();
        }

        [Fact]
        public async Task Async_Right_Map_returns_mapped_value()
        {
            var instance = new MyClass { Property = "Some value" };
            Maybe<MyClass> maybe = instance;
            var result = new MyClass { Property = "Different value" };

            Maybe<MyClass> maybe2 = await maybe.Map(ExpectAndReturn(instance, result.AsTask()));

            maybe2.HasValue.Should().BeTrue();
            maybe2.Value.Should().Be(result);
        }

        [Fact]
        public async Task Async_Right_Map_returns_no_value_if_initial_maybe_is_null()
        {
            Maybe<MyClass> maybe = Maybe<MyClass>.None;
            var result = new MyClass { Property = "Different value" };
            
            Maybe<MyClass> maybe2 = await maybe.Map(ExpectAndReturn(null, result.AsTask()));

            maybe2.HasValue.Should().BeFalse();
        }

        [Fact]
        public async Task Async_Both_Map_returns_mapped_value()
        {
            var instance = new MyClass { Property = "Some value" };
            Task<Maybe<MyClass>> maybeTask = GetMaybeTask(instance);
            var result = new MyClass { Property = "Different value" };

            Maybe<MyClass> maybe2 = await maybeTask.Map(ExpectAndReturn(instance, result.AsTask()));

            maybe2.HasValue.Should().BeTrue();
            maybe2.Value.Should().Be(result);
        }

        [Fact]
        public async Task Async_Both_Map_returns_no_value_if_initial_maybe_is_null()
        {
            Task<Maybe<MyClass>> maybeTask = GetMaybeTask(Maybe<MyClass>.None);
            var result = new MyClass { Property = "Different value" };

            Maybe<MyClass> maybe2 = await maybeTask.Map(ExpectAndReturn(null, result.AsTask()));

            maybe2.HasValue.Should().BeFalse();
        }

        [Fact]
        public async Task Async_Left_Bind_returns_no_value_if_initial_maybe_is_null()
        {
            Task<Maybe<MyClass>> maybeTask = GetMaybeTask(Maybe<MyClass>.None);
            var result = new MyClass { Property = "Different value" };

            Maybe<MyClass> maybe2 = await maybeTask.Bind(ExpectAndReturnMaybe(null, result));

            maybe2.HasValue.Should().BeFalse();
        }

        [Fact]
        public async Task Async_Left_Bind_returns_no_value_if_selector_returns_null()
        {
            var instance = new MyClass { Property = "Some value" };
            Task<Maybe<MyClass>> maybeTask = GetMaybeTask(instance);

            Maybe<MyClass> maybe2 = await maybeTask.Bind(ExpectAndReturn(instance, Maybe<MyClass>.None));

            maybe2.HasValue.Should().BeFalse();
        }

        [Fact]
        public async Task Async_Left_Bind_returns_value_if_selector_returns_value()
        {
            var instance = new MyClass { Property = "Some value" };
            Task<Maybe<MyClass>> maybeTask = GetMaybeTask(instance);
            var result = new MyClass { Property = "Different value" };

            Maybe<MyClass> maybe2 = await maybeTask.Bind(ExpectAndReturnMaybe(instance, result));

            maybe2.HasValue.Should().BeTrue();
            maybe2.Value.Should().Be(result);
        }

        [Fact]
        public async Task Async_Right_Bind_returns_no_value_if_initial_maybe_is_null()
        {
            Maybe<MyClass> maybe = Maybe<MyClass>.None;
            var result = new MyClass { Property = "Different value" };

            Maybe<MyClass> maybe2 = await maybe.Bind(ExpectAndReturnAsyncMaybe(null, result));

            maybe2.HasValue.Should().BeFalse();
        }

        [Fact]
        public async Task Async_Right_Bind_returns_no_value_if_selector_returns_null()
        {
            var instance = new MyClass { Property = "Some value" };
            Maybe<MyClass> maybe = instance;

            Maybe<MyClass> maybe2 = await maybe.Bind(ExpectAndReturnAsync(instance, Maybe<MyClass>.None));

            maybe2.HasValue.Should().BeFalse();
        }

        [Fact]
        public async Task Async_Right_Bind_returns_value_if_selector_returns_value()
        {
            var instance = new MyClass { Property = "Some value" };
            Maybe<MyClass> maybe = instance;
            var result = new MyClass { Property = "Different value" };

            Maybe<MyClass> maybe2 = await maybe.Bind(ExpectAndReturnAsyncMaybe(instance, result));

            maybe2.HasValue.Should().BeTrue();
            maybe2.Value.Should().Be(result);
        }

        [Fact]
        public async Task Async_Both_Bind_returns_no_value_if_initial_maybe_is_null()
        {
            Task<Maybe<MyClass>> maybeTask = Maybe<MyClass>.None.AsTask();
            var result = new MyClass { Property = "Different value" };

            Maybe<MyClass> maybe2 = await maybeTask.Bind(ExpectAndReturnAsyncMaybe(null, result));

            maybe2.HasValue.Should().BeFalse();
        }

        [Fact]
        public async Task Async_Both_Bind_returns_no_value_if_selector_returns_null()
        {
            var instance = new MyClass { Property = "Some value" };
            Task<Maybe<MyClass>> maybeTask = GetMaybeTask(instance);

            Maybe<MyClass> maybe2 = await maybeTask.Bind(ExpectAndReturnAsync(instance, Maybe<MyClass>.None));

            maybe2.HasValue.Should().BeFalse();
        }

        [Fact]
        public async Task Async_Both_Bind_returns_value_if_selector_returns_value()
        {
            var instance = new MyClass { Property = "Some value" };
            Task<Maybe<MyClass>> maybeTask = GetMaybeTask(instance);
            var result = new MyClass { Property = "Different value" };

            Maybe<MyClass> maybe2 = await maybeTask.Bind(ExpectAndReturnAsyncMaybe(instance, result));

            maybe2.HasValue.Should().BeTrue();
            maybe2.Value.Should().Be(result);
        }

        private static Task<Maybe<MyClass>> GetMaybeTask(Maybe<MyClass> maybe) => maybe.AsTask();

        private static Func<MyClass, T> ExpectAndReturn<T>(MyClass expected, T result) => actual =>
        {
            actual.Should().Be(expected);
            return result;
        };

        private static Func<MyClass, Maybe<T>> ExpectAndReturnMaybe<T>(MyClass expected, T result) => actual =>
        {
            actual.Should().Be(expected);
            return result;
        };

        private static Func<MyClass, Task<T>> ExpectAndReturnAsync<T>(MyClass expected, T result) => actual =>
        {
            actual.Should().Be(expected);
            return result.AsTask();
        };

        private static Func<MyClass, Task<Maybe<MyClass>>> ExpectAndReturnAsyncMaybe(MyClass expected, MyClass result) => actual =>
        {
            actual.Should().Be(expected);
            return GetMaybeTask(result);
        };

        private class MyClass
        {
            public string Property { get; set; }
            public int IntProperty { get; set; }
        }
    }
}