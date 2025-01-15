﻿using Microsoft.AspNetCore.Diagnostics;
using SmsHub.Common.Exceptions;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using System.Net;

namespace SmsHub.Api.ExceptionHandlers
{
    internal sealed class GlobalExceptionHandler : IExceptionHandler
    {
        //private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            //_logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            if (exception is BaseException ourAppException)
            {
                var message = $"خطا در پردازش اطلاعات: {exception.Message}, توضیحات بیشتر:{exception.InnerException?.Message}";

                var problemDetails = new ApiResponseEnvelope<string>(StatusCodes.Status400BadRequest, null, new[] { new ApiError(message, (int)HttpStatusCode.BadRequest) });

                httpContext.Response.StatusCode = problemDetails.HttpStatusCode;

                await httpContext.Response
                    .WriteAsJsonAsync(problemDetails, cancellationToken);
                return await ValueTask.FromResult(true);
            }
            else
            {
                var message = $"Exception occurred: Message: {exception.Message}, Inner Exception:{exception.InnerException.Message}";
                //_logger.LogError(
                //    exception, "Exception occurred: {Message}", exception.Message);

                var problemDetails = new ApiResponseEnvelope<string>(StatusCodes.Status500InternalServerError, null, new[] { new ApiError(message, StatusCodes.Status500InternalServerError) });

                httpContext.Response.StatusCode = problemDetails.HttpStatusCode;

                await httpContext.Response
                    .WriteAsJsonAsync(problemDetails, cancellationToken);

                return await ValueTask.FromResult(true);
            }
        }
    }
}
