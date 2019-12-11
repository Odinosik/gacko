using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace GACKO.Shared.Models
{
    /// <summary>
    /// Class packing errors and exceptions to a reusable form
    /// </summary>
    public class GackoError
    {
        /// <summary>
        /// Exception Message
        /// </summary>
        public string ExceptionMessage { get; }
        /// <summary>
        /// Flag indicating whether the Error is an Exception
        /// </summary>
        public bool IsException { get; }
        /// <summary>
        /// Fluent Validation Errors
        /// </summary>
        public IList<ValidationFailure> ValidationErrors { get; }

        public GackoError(Exception ex)
        {
            this.ExceptionMessage = ex.Message;
            this.IsException = true;
        }

        public GackoError(IList<ValidationFailure> validationErrors)
        {
            this.ValidationErrors = validationErrors;
            this.IsException = false;
        }
    }
}
