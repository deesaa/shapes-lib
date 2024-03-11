namespace ShapeLib
{
    public class UseExample
    {
        public void Run()
        {
            var shapes = new ShapeFactory();
            var operations = new ShapeOperationsFactory();
            operations.AddOperation<ShapeOperationEquilateralTriangleCheck>();

            
            shapes.AddShape<ShapeTriangle>();
            shapes.AddShape<ShapeCircle>();
            operations.AddOperation<ShapeOperationArea>();
            
            
            var triangleBuilder = shapes.BeginNewShape(typeof(ShapeTriangle));
            foreach (var shapeParameterSetter in triangleBuilder.ParameterSetters())
                shapeParameterSetter.Set(3);

            IShape triangleShape = triangleBuilder.EndNewShape();

            var availableOperations = operations.AvailableFor(triangleShape).ToList();

            var rightTriangleCheckOperation = new ShapeOperationEquilateralTriangleCheck();
            rightTriangleCheckOperation.ExecuteOn(triangleShape);
            var isRightTriangle = rightTriangleCheckOperation.Result;

            IShapeOperation operation = operations.GetOperation(typeof(ShapeOperationArea));
            operation.ExecuteOn(triangleShape);
            var result = (int)operation.Result;
            Console.WriteLine($"Result is {operation.Result}");
        }
    }
}