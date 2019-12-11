using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace GACKO.Shared.Exceptions
{
    /// <summary>
    /// Exception thrown from services while performing business logic activities
    /// </summary>
    public class ServiceException : Exception
    {
        private readonly string _message;
        /// <summary>
        /// Exception Message
        /// </summary>
        public override string Message => _message;
        /// <summary>
        /// HTML Status Code associated with the exception
        /// </summary>
        public int StatusCode { get; set; }
        /// <summary>
        /// Service name the exception was thrown from
        /// </summary>
        public string ServiceName { get; set; }
        /// <summary>
        /// Fluent Validation Errors
        /// </summary>
        public IList<ValidationFailure> Errors { get; set; }

        public ServiceException(string serviceName, string message, int statusCode = 500, IList<ValidationFailure> errors = null)
        {
            ServiceName = serviceName;
            _message = message;
            Errors = errors;
        }
    }
}
