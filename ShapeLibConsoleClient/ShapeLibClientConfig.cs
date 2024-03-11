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
    
    public static ShapeOperationsFactory CreateOperationsFactory()
    {
        var operations = new ShapeOperationsFactory();
        operations.AddOperation<ShapeOperationArea>();
        operations.AddOperation<ShapeOperationRightTriangleCheck>();
        operations.AddOperation<ShapeOperationEquilateralTriangleCheck>();
        return operations;
    }
}