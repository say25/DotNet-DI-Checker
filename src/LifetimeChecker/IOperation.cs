using System;

namespace LifetimeChecker
{
    public interface IOperation
    {
        Guid OperationId { get; }
    }
}
