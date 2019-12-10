using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace GACKO.Shared.Exceptions
{
    public class ServiceException : Exception
    {
        private readonly string _message;
        public override string Message { get; }
        public int StatusCode { get; set; }
        public string ServiceName { get; set; }
        public IList<ValidationFailure> Errors { get; set; }

        public ServiceException(string serviceName, string message, int statusCode = 500, IList<ValidationFailure> errors = null) : base(message)
        {
            this.ServiceName = serviceName;
            Errors = errors;
        }
    }
}
