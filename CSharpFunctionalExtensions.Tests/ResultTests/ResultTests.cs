using FluentAssertions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CSharpFunctionalExtensions.Tests.ResultTests
{
    public class ResultTests : TestBase
    { 
        [Fact]
        public void Success_argument_is_null_Success_result_expected()
        {
            Result result = Result.Success<string>(null);

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Fail_argument_is_default_Fail_result_expected()
        {
            Result<string, int> result = Result.Failure<string, int>(0);

            result.IsFailure.Should().BeTrue();
        }

        [Fact]
        public void Fail_argument_is_not_default_Fail_result_expected()
        {
            Result<string, int> result = Result.Failure<string, int>(1);

            result.IsFailure.Should().BeTrue();
        }

        [Fact]
        public void Fail_argument_is_null_Exception_expected()
        {
            var exception = Record.Exception(() =>
                Result.Failure<string, string>(null));
            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public void CreateFailure_value_is_null_Success_result_expected()
        {
            Result result = Result.FailureIf<string>(false, null, null);

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void CreateFailure_error_is_null_Exception_expected()
        {
            var exception = Record.Exception(() =>
                Result.FailureIf<string, string>(true, null, null));

            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public void CreateFailure_error_is_default_Failure_result_expected()
        {
            Result<bool, int> result = Result.FailureIf<bool, int>(true, false, 0);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(0);
        }

        [Fact]
        public void CreateFailure_argument_is_false_Success_result_expected()
        {
            Result result = Result.FailureIf(false, string.Empty);

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void CreateFailure_argument_is_true_Failure_result_expected()
        {
            Result result = Result.FailureIf(true, "simple result error");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("simple result error");
        }

        [Fact]
        public void CreateFailure_predicate_is_false_Success_result_expected()
        {
            Result result = Result.FailureIf(() => false, string.Empty);

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void CreateFailure_predicate_is_true_Failure_result_expected()
        {
            Result result = Result.FailureIf(() => true, "predicate result error");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("predicate result error");
        }

        [Fact]
        public async Task CreateFailure_async_predicate_is_false_Success_result_expected()
        {
            Result result = await Result.FailureIf(() => Task.FromResult(false), string.Empty);

            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task CreateFailure_async_predicate_is_true_Failure_result_expected()
        {
            Result result = await Result.FailureIf(() => Task.FromResult(true), "predicate result error");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("predicate result error");
        }

        [Fact]
        public void CreateFailure_generic_argument_is_false_Success_result_expected()
        {
            byte val = 7;
            Result<byte> result = Result.FailureIf(false, val, string.Empty);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(val);
        }

        [Fact]
        public void CreateFailure_generic_argument_is_true_Failure_result_expected()
        {
            double val = .56;
            Result<double> result = Result.FailureIf(true, val, "simple result error");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("simple result error");
        }

        [Fact]
        public void CreateFailure_generic_predicate_is_false_Success_result_expected()
        {
            DateTime val = new DateTime(2000, 1, 1);

            Result<DateTime> result = Result.FailureIf(() => false, val, string.Empty);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(val);
        }

        [Fact]
        public void CreateFailure_generic_predicate_is_true_Failure_result_expected()
        {
            string val = "string value";

            Result<string> result = Result.FailureIf(() => true, val, "predicate result error");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("predicate result error");
        }

        [Fact]
        public async Task CreateFailure_generic_async_predicate_is_false_Success_result_expected()
        {
            int val = 42;

            Result<int> result = await Result.FailureIf(() => Task.FromResult(false), val, string.Empty);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(val);
        }

        [Fact]
        public async Task CreateFailure_generic_async_predicate_is_true_Failure_result_expected()
        {
            bool val = true;

            Result<bool> result = await Result.FailureIf(() => Task.FromResult(true), val, "predicate result error");

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("predicate result error");
        }


        [Fact]
        public void CreateFailure_error_generic_argument_is_false_Success_result_expected()
        {
            byte val = 7;
            Result<byte, Error> result = Result.FailureIf(false, val, new Error());

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(val);
        }

        [Fact]
        public void CreateFailure_error_generic_argument_is_true_Failure_result_expected()
        {
            double val = .56;
            var error = new Error();

            Result<double, Error> result = Result.FailureIf(true, val, error);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
        }

        [Fact]
        public void CreateFailure_error_generic_predicate_is_false_Success_result_expected()
        {
            DateTime val = new DateTime(2000, 1, 1);

            Result<DateTime, Error> result = Result.FailureIf(() => false, val, new Error());

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(val);
        }

        [Fact]
        public void CreateFailure_error_generic_predicate_is_true_Failure_result_expected()
        {
            string val = "string value";
            var error = new Error();

            Result<string, Error> result = Result.FailureIf(() => true, val, error);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
        }

        [Fact]
        public async Task CreateFailure_error_generic_async_predicate_is_false_Success_result_expected()
        {
            int val = 42;

            Result<int, Error> result = await Result.FailureIf(() => Task.FromResult(false), val, new Error());

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(val);
        }

        [Fact]
        public async Task CreateFailure_error_generic_async_predicate_is_true_Failure_result_expected()
        {
            bool val = true;
            var error = new Error();

            Result<bool, Error> result = await Result.FailureIf(() => Task.FromResult(true), val, error);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be(error);
        }

        [Fact]
        public void Can_work_with_nullable_sructs()
        {
            Result<DateTime?> result = Result.Success((DateTime?)null);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(null);
        }

        [Fact]
        public void Can_work_with_maybe_of_struct()
        {
            Maybe<DateTime> maybe = Maybe<DateTime>.None;

            Result<Maybe<DateTime>> result = Result.Success(maybe);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(Maybe<DateTime>.None);
        }

        [Fact]
        public void Can_work_with_maybe_of_ref_type()
        {
            Maybe<string> maybe = Maybe<string>.None;

            Result<Maybe<string>> result = Result.Success(maybe);

            result.IsSuccess.Should().BeTrue();
            result.Value.Should().Be(Maybe<string>.None);
        }
    }
}