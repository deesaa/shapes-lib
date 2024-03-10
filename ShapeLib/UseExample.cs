namespace ShapeLib
{
    public class UseExample
    {
        public void Run()
        {
            var factory = new ShapeFactory();
            factory.AddShape<ShapeTriangle>();
            factory.AddShape<ShapeCircle>();
            
            var operations = new ShapeOperations();
            operations.AddOperation<ShapeOperationEquilateralTriangleCheck>();
            operations.AddOperation<ShapeOperationArea>();
            
            var triangleBuilder = factory.BeginNewShape(typeof(ShapeTriangle));
            foreach (var shapeParameterSetter in triangleBuilder.ParameterSetters())
                shapeParameterSetter.Set(3);

            var triangleShape = triangleBuilder.EndNewShape();

            var availableOperations = operations.AvailableFor(triangleShape).ToList();

            var rightTriangleCheckOperation = new ShapeOperationEquilateralTriangleCheck();
            rightTriangleCheckOperation.ExecuteOn(triangleShape);
            var isRightTriangle = rightTriangleCheckOperation.Result;

            IShapeOperation operation = operations.GetOperation(typeof(ShapeOperationArea));
            operation.ExecuteOn(triangleShape);
            var result = (int)operation.Result;

        }
    }
}