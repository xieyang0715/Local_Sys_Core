using Lifetime.Core.Lifetime.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lifetime.Core.Lifetime.Service
{
    public class MyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        private readonly IOperationTransient _transientOperation;
        private readonly IOperationSingleton _singletonOperation;

        public MyMiddleware(RequestDelegate next, ILogger<MyMiddleware> logger,
            IOperationTransient transientOperation,
            IOperationSingleton singletonOperation)
        {
            _logger = logger;
            _transientOperation = transientOperation;
            _singletonOperation = singletonOperation;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context,
            IOperationScoped scopedOperation)
        {
            var vv = (Operation)context.RequestServices.GetService(typeof(IOperationScoped));
            _logger.LogInformation("Transient: " + _transientOperation.OperationId);
            _logger.LogInformation("Scoped: " + vv.OperationId);
            _logger.LogInformation("Singleton: " + _singletonOperation.OperationId);

            await _next(context);
        }
    }
}
