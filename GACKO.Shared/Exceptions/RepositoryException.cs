using System;
using System.Reflection.Metadata.Ecma335;
using GACKO.Shared.Enums;

namespace GACKO.Shared.Exceptions
{
    /// <summary>
    /// Exception thrown from repositories while accessing database
    /// </summary>
    public class RepositoryException : Exception
    {
        private readonly string _message;
        /// <summary>
        /// Exception Message
        /// </summary>
        public override string Message => _message;
        /// <summary>
        /// HTML Status Code associated with the exception
        /// </summary>
        public int StatusCode { get; }

        public RepositoryException(string modelName, eRepositoryExceptionType exceptionType, int statusCode = 500)
        {
            StatusCode = statusCode;

            switch (exceptionType)
            {
                case eRepositoryExceptionType.Create:
                    _message = $"Failed to create {modelName}.";
                    break;
                case eRepositoryExceptionType.Get:
                    _message = $"Failed to retrieve {modelName}.";
                    break;
                case eRepositoryExceptionType.Update:
                    _message = $"Failed to update {modelName}.";
                    break;
                case eRepositoryExceptionType.Delete:
                    _message = $"Failed to delete {modelName}.";
                    break;
            }
        }
    }
}
