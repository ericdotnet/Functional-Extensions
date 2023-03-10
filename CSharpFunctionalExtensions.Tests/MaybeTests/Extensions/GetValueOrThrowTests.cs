﻿using System;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.MaybeTests.Extensions
{
    public class GetValueOrThrowTests : MaybeTestBase
    {

        [Fact]
        public void GetValueOrThrow_throws_with_message_if_source_is_empty()
        {
            const string errorMessage = "Maybe is none";

            Func<int> func = () =>
            {
                var maybe = Maybe<int>.None;
                return maybe.GetValueOrThrow(errorMessage);
            };

            func.Should().Throw<InvalidOperationException>().WithMessage(errorMessage);
        }

        [Fact]
        public void GetValueOrThrow_throws_with_custom_exception_if_source_is_empty()
        {
            const string errorMessage = "Maybe is none";

            Func<int> func = () =>
            {
                var maybe = Maybe<int>.None;
                return maybe.GetValueOrThrow(new DummyDomainException(errorMessage));
            };

            func.Should().Throw<DummyDomainException>().WithMessage(errorMessage);
        }

        [Fact]
        public void GetValueOrThrow_returns_value_if_source_has_value()
        {
            const int value = 1;
            var maybe = Maybe.From(value);
            
            const string errorMessage = "Maybe is none";
            var result = maybe.GetValueOrThrow(errorMessage);

            result.Should().Be(value);
        }

        private class DummyDomainException : Exception
        {
            public DummyDomainException(string message) 
                : base(message)
            {
            }
        }
    }
}
