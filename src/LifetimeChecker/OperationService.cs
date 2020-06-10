using System;

namespace LifetimeChecker
{
    public class OperationService
    {
        // Public to Inspect in Debug
        public readonly IOperationTransient TransientOperation;
        public readonly IOperationScoped ScopedOperation;
        public readonly IOperationSingleton SingletonOperation;
        public readonly IOperationSingletonInstance SingletonInstanceOperation;
        public int _timesCalled { get; private set; } = 0;
        public readonly Guid Id = Guid.NewGuid();

        public OperationService(
            IOperationTransient transientOperation,
            IOperationScoped scopedOperation,
            IOperationSingleton singletonOperation,
            IOperationSingletonInstance instanceOperation)
        {
            TransientOperation = transientOperation;
            ScopedOperation = scopedOperation;
            SingletonOperation = singletonOperation;
            SingletonInstanceOperation = instanceOperation;
        }

        public void WriteMessage()
        {
            Console.WriteLine();
            Console.WriteLine($"Id: {Id}: Called {_timesCalled++}");
            Console.WriteLine($"{nameof(TransientOperation)}-{TransientOperation.OperationId}");
            Console.WriteLine($"{nameof(ScopedOperation)}-{ScopedOperation.OperationId}");
            Console.WriteLine($"{nameof(SingletonOperation)}-{SingletonOperation.OperationId}");
            Console.WriteLine($"{nameof(SingletonInstanceOperation)}-{SingletonInstanceOperation.OperationId}");
            Console.WriteLine();
        }
    }
}
