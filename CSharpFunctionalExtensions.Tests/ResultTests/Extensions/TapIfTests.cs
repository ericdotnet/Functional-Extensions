﻿using FluentAssertions;
using System;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public class TapIf : TestBase
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_executes_action_conditionally_and_returns_self(bool condition)
        {
            Result result = Result.Success();
            bool actionExecuted = false;
            Action action = () => actionExecuted = true;

            var returned = result.TapIf(condition, action);

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_executes_action_conditionally_and_returns_self(bool condition)
        {
            Result<T> result = Result.Success(T.Value);
            bool actionExecuted = false;
            Action action = () => actionExecuted = true;

            var returned = result.TapIf(condition, action);

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_executes_action_T_conditionally_and_returns_self(bool condition)
        {
            Result<T> result = Result.Success(T.Value);
            bool actionExecuted = false;
            Action<T> action = _ => actionExecuted = true;

            var returned = result.TapIf(condition, action);

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_E_executes_action_conditionally_and_returns_self(bool condition)
        {
            Result<T, E> result = Result.Success<T, E>(T.Value);
            bool actionExecuted = false;
            Action action = () => actionExecuted = true;

            var returned = result.TapIf(condition, action);

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_E_executes_action_T_conditionally_and_returns_self(bool condition)
        {
            Result<T, E> result = Result.Success<T, E>(T.Value);
            bool actionExecuted = false;
            Action<T> action = _ => actionExecuted = true;

            var returned = result.TapIf(condition, action);

            actionExecuted.Should().Be(condition);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_executes_action_based_on_func_and_returns_self(bool value)
        {
            Result<K> result = Result.Success(K.FromBool(value));
            bool actionExecuted = false;
            Func<K, bool> condition = k => k.Value;
            Action action = () => actionExecuted = true;

            var returned = result.TapIf(condition, action);

            actionExecuted.Should().Be(value);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_executes_action_T_based_on_func_and_returns_self(bool value)
        {
            Result<K> result = Result.Success(K.FromBool(value));
            bool actionExecuted = false;
            Func<K, bool> condition = k => k.Value;
            Action<K> action = _ => actionExecuted = true;

            var returned = result.TapIf(condition, action);

            actionExecuted.Should().Be(value);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_E_executes_action_based_on_func_and_returns_self(bool value)
        {
            Result<K, E> result = Result.Success<K, E>(K.FromBool(value));
            bool actionExecuted = false;
            Func<K, bool> condition = k => k.Value;
            Action action = () => actionExecuted = true;

            var returned = result.TapIf(condition, action);

            actionExecuted.Should().Be(value);
            result.Should().Be(returned);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TapIf_T_E_executes_action_T_based_on_func_and_returns_self(bool value)
        {
            Result<K, E> result = Result.Success<K, E>(K.FromBool(value));
            bool actionExecuted = false;
            Func<K, bool> condition = k => k.Value;
            Action<K> action = _ => actionExecuted = true;

            var returned = result.TapIf(condition, action);

            actionExecuted.Should().Be(value);
            result.Should().Be(returned);
        }
    }
}
