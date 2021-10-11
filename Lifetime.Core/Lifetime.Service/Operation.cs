using Lifetime.Core.Lifetime.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lifetime.Core.Lifetime.Service
{
    public class Operation : IOperationTransient, IOperationScoped, IOperationSingleton
    {
        public Operation()
        {
            OperationId = Guid.NewGuid().ToString()[^4..];
        }

        public string OperationId { get; }
    }
}
