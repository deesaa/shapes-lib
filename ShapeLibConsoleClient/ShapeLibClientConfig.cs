using ShapeLib;

namespace ShapeLibConsoleClient;

public static class ShapeLibClientConfig
{       
    public static ShapeFactory CreateShapeFactory()
    {
        var factory = new ShapeFactory();
        factory.AddShape<ShapeTriangle>();
        factory.AddShape<ShapeCircle>();
        return factory;
    }
    
    public static ShapeOperations CreateOperationsFactory()
    {
        var operations = new ShapeOperations();
        operations.AddOperation<ShapeOperationArea>();
        operations.AddOperation<ShapeOperationRightTriangleCheck>();
        operations.AddOperation<ShapeOperationEquilateralTriangleCheck>();
        return operations;
    }
}