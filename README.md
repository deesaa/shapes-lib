# shapes-lib 

Library for creating different geometry shapes and performing operations over them

### Projects in Solution

> `ShapesLib`: Core library

> `ShapesLibConsoleClient`: Console example of library usage

> `ShapesLibTests`: Unit tests for core library
# How To:

## Fast Check

> Clone repository -> open `ShapesLibConsoleClient` project in solution -> run client application

> Or run `ShapeLibConsoleClient.exe` in Release folder in `ShapesLibConsoleClient` project

## Initialize
Init ShapeFactory and ShapeOperationsFactory
```c#
var shapes = new ShapeFactory();
var operations = new ShapeOperationsFactory();

//Register types of shapes and types of operations that exist.
 shapes.AddShape<ShapeTriangle>();
 shapes.AddShape<ShapeCircle>();
 operations.AddOperation<ShapeOperationArea>();
 operations.AddOperation<ShapeOperationEquilateralTriangleCheck>();
```
## Create a shape
```c#
//Start building new shape.
var triangleBuilder = shapes.BeginNewShape(typeof(ShapeTriangle));

//Get setters for parameters of your shape. You can find exact name of the parameter inside setter object.
foreach (var shapeParameterSetter in triangleBuilder.ParameterSetters())
                shapeParameterSetter.Set(3);

//When all parameters are set, you can finish your shape
IShape triangleShape = triangleBuilder.EndNewShape();
```
## Perform operation over shape
```c#
//Get a list of operation types that can be performed over target shape
var availableOperations = operations.AvailableFor(triangleShape);

//Select any type and create get object of that operation
var operationType = availableOperations.First() //.First() for example
IShapeOperation operation = operations.GetOperation(operationType);

//Execute operation over shape and get a result
operation.ExecuteOn(triangleShape);
Console.WriteLine($"Result is {operation.Result}");
```

# Adding new type of a shape
Every shape has to implement IShape interface.
ShapeParametersScheme property defines parameters that must be provided by user to define a shape.
Let's create new shape: Quad
```c#
    public class ShapeQuad : IShape
    {
        //Human readable keys for parameters of the shape
        private const string SideA = "SideA";
        private const string SideB = "SideB";
        
        //Scheme of shape parameters connecting keys and default value + validation 
        private static readonly Dictionary<string, ShapeParameter> Scheme = new() 
        {
            { SideA, new ShapeParameter(0, ValidGreaterThan.Zero)},
            { SideB, new ShapeParameter(0, ValidGreaterThan.Zero)} 
        };  
        
        private float _sideA;
        private float _sideB;
        private float _area;
        
        public IReadOnlyDictionary<string, ShapeParameter> ShapeParametersScheme => Scheme;
        public string ShapeName => GetType().Name;
        
        //Called from shape builder with parameters that user passed
        public void SetParameters(Dictionary<string, float> shapeParameters)
        {
            _sideA = shapeParameters[SideA];
            _sideB = shapeParameters[SideB];
            _area = _sideA * _sideB;
        }
        
        //IShape uses IArea as any shape can has area
        public float GetArea() => _area;
    }
```

Now we have to add new shape ShapeFactory

```c#
_factory = new ShapeFactory();
_factory.AddShape<ShapeTriangle>();
_factory.AddShape<ShapeCircle>();
_factory.AddShape<ShapeQuad>(); //Adding new ShapeQuad
```
Done

# Operations

Calculating an area of a shape and checking is a triangle right - 
all of this are implementations of the IShapeOperation interface. 
You can create your custom operations and add them to the ShapeOperationsFactory

```c#
var operations = new ShapeOperationsFactory();
// Adding new type of operation
operations.AddOperation<ShapeOperationEquilateralTriangleCheck>();
```