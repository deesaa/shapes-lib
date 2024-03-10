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
}