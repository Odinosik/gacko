using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace GACKO.Shared.Models
{
    public class GackoError
    {
        public string ExceptionMessage { get; }
        public bool IsException { get; }
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
