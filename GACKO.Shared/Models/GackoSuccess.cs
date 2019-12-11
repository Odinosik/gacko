using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace GACKO.Shared.Models
{
    /// <summary>
    /// Class packing success messages to a reusable form
    /// </summary>
    public class GackoSuccess
    {
        /// <summary>
        /// IsSuccess Message
        /// </summary>
        public string SuccessMessage { get; }

        public GackoSuccess(string message)
        {
            this.SuccessMessage = message;
        }
    }
}
