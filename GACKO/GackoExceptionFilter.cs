using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using GACKO.Shared.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GACKO
{
    public class GackoExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            GackoError apiError = null;
            if (context.Exception is RepositoryException)
            {
                // handle explicit 'known' API errors
                var ex = context.Exception as RepositoryException;
                context.Exception = null;
                apiError = new GackoError(ex.Message);

                context.HttpContext.Response.StatusCode = ex.StatusCode;
            }
            else if (context.Exception is ServiceException)
            {
                // handle explicit 'known' API errors
                var ex = context.Exception as ServiceException;
                context.Exception = null;
                apiError = new GackoError(ex.Message);
                apiError.errors = ex.Errors;

                context.HttpContext.Response.StatusCode = ex.StatusCode;
            }
            else if (context.Exception is UnauthorizedAccessException)
            {
                apiError = new GackoError("Unauthorized Access");
                context.HttpContext.Response.StatusCode = 401;

                // handle logging here
            }
            else
            {
                // Unhandled errors
#if !DEBUG
                var msg = "An unhandled error occurred.";                
                string stack = null;
#else
                var msg = context.Exception.GetBaseException().Message;
                string stack = context.Exception.StackTrace;
#endif

                apiError = new GackoError(msg);
                apiError.detail = stack;

                context.HttpContext.Response.StatusCode = 500;

                // handle logging here
            }

            context.Result = new JsonResult(apiError);
            base.OnException(context);
        }
    }
}


public class GackoError
{
    public string message { get; set; }
    public bool isError { get; set; }
    public string detail { get; set; }
    public IList<ValidationFailure> errors { get; set; }

    public GackoError(string message)
    {
        this.message = message;
        isError = true;
    }

    public GackoError(ModelStateDictionary modelState)
    {
        this.isError = true;
        if (modelState != null && modelState.Any(m => m.Value.Errors.Count > 0))
        {
            message = "Please correct the specified errors and try again.";
            //errors = modelState.SelectMany(m => m.Value.Errors).ToDictionary(m => m.Key, m=> m.ErrorMessage);
            //errors = modelState.SelectMany(m => m.Value.Errors.Select( me => new KeyValuePair<string,string>( m.Key,me.ErrorMessage) ));
            //errors = modelState.SelectMany(m => m.Value.Errors.Select(me => new ModelError { FieldName = m.Key, ErrorMessage = me.ErrorMessage }));
        }
    }
}