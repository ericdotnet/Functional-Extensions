﻿using System.ComponentModel.DataAnnotations;

namespace CSharpFunctionalExtensions.Json.Serialization
{
    /// <summary>
    /// Alternative entry-point for <see cref="UnitResultDto{E}" /> to avoid ambiguous calls
    /// </summary>
    internal static partial class UnitResultDto
    {
        /// <summary>
        /// Creates a failure result with the given error.
        /// </summary>
        public static UnitResultDto<E> Failure<E>(E error)
        {
            return new UnitResultDto<E>(false, error);
        }

        /// <summary>
        /// Creates a success <see cref="UnitResultDto{E}" />.
        /// </summary>
        public static UnitResultDto<E> Success<E>()
        {
            return new UnitResultDto<E>(true);
        }
    }

    internal record UnitResultDto<E>([property:Required] bool IsSuccess, [property:Required] E? Error = default);
}
