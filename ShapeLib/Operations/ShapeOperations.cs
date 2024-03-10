namespace ShapeLib
{
    public class ShapeOperations
    {
        private Dictionary<Type, OperationFactoryData> _shapeOperationFactories = new();

        public void AddOperation<T, T2>() where T : IShapeOperation, new()
            where T2 : IShapeOperationExecuteCondition, new()
        {
            _shapeOperationFactories.TryAdd(typeof(T), new OperationFactoryData
            {
                OperationFactory = () => new T(),
                ExecuteCondition = new T2()
            });
        }
        
        public void AddOperation<T>() where T : IShapeOperation, IShapeOperationExecuteCondition, new()
        {
            _shapeOperationFactories.TryAdd(typeof(T), new OperationFactoryData
            {
                OperationFactory = () => new T(),
                ExecuteCondition = new T()
            });
        }

        public IEnumerable<Type> AvailableFor(IShape triangleShape)
        {
            foreach (var operationFactory in _shapeOperationFactories)
            {
                if(!operationFactory.Value.ExecuteCondition.CanExecuteOn(triangleShape)) continue;
                yield return operationFactory.Key;
            }
        }

        private class OperationFactoryData
        {
            public Func<IShapeOperation> OperationFactory;
            public IShapeOperationExecuteCondition ExecuteCondition;
        }

        public IShapeOperation GetOperation(Type type) => _shapeOperationFactories[type].OperationFactory();
    }
}