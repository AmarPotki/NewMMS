﻿namespace Framework
{
    public partial struct Result
    {
        /// <summary>
        ///     Creates a result whose success/failure reflects the supplied condition. Opposite of SuccessIf().
        /// </summary>
        public static Result FailureIf(bool isFailure, string error)
            => SuccessIf(!isFailure, error);

        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of SuccessIf().
        /// </summary>
        public static Result FailureIf(Func<bool> failurePredicate, string error)
            => SuccessIf(!failurePredicate(), error);
        
        /// <summary>
        ///     Creates a result whose success/failure reflects the supplied condition. Opposite of SuccessIf().
        /// </summary>
        public static Result<T> FailureIf<T>(bool isFailure, T value, string error)
            => SuccessIf(!isFailure, value, error);

        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of SuccessIf().
        /// </summary>
        public static Result<T> FailureIf<T>(Func<bool> failurePredicate, in T value, string error)
            => SuccessIf(!failurePredicate(), value, error);
        
        /// <summary>
        ///     Creates a result whose success/failure reflects the supplied condition. Opposite of SuccessIf().
        /// </summary>
        public static Result<T, E> FailureIf<T, E>(bool isFailure, in T value, in E error)
            => SuccessIf(!isFailure, value, error);

        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of SuccessIf().
        /// </summary>
        public static Result<T, E> FailureIf<T, E>(Func<bool> failurePredicate, in T value, in E error)
            => SuccessIf(!failurePredicate(), value, error);
    }

    public static partial class UnitResult
    {
        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of SuccessIf().
        /// </summary>
        public static UnitResult<E> FailureIf<E>(bool isFailure, in E error)
            => SuccessIf(!isFailure, error);

        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of SuccessIf().
        /// </summary>
        public static UnitResult<E> FailureIf<E>(Func<bool> failurePredicate, in E error)
            => SuccessIf(!failurePredicate(), error);

        /// <summary>
        ///     Creates a result whose success/failure depends on the supplied predicate. Opposite of SuccessIf().
        /// </summary>
        public static async Task<UnitResult<E>> FailureIf<E>(Func<Task<bool>> failurePredicate, E error)
        {
            bool isFailure = await failurePredicate().DefaultAwait();
            return SuccessIf(!isFailure, error);
        }
    }
}
