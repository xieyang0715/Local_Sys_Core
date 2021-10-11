using System;
using System.Collections.Generic;
using System.Text;

namespace Lifetime.Scop.Core
{
    public interface IOperation
    {
        string OperationId { get; }
    }

    public interface IOperationTransient : IOperation { }
    public interface IOperationScoped : IOperation { }
    public interface IOperationSingleton : IOperation { }
}
