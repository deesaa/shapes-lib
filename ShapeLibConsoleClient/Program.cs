using ShapeLib;
using ShapeLibConsoleClient;

var factory = ShapeLibClientConfig.CreateShapeFactory();
var shapeTypes = factory.AvailableShapes().ToList();
Type selectedShapeType = null;

while (true)
{
    var selectedShapeIndex = -1;
    try
    {
        Console.WriteLine("Print a number from the list to select a type for the Shape");
        for (int i = 0; i < shapeTypes.Count; i++)
        {
            Console.WriteLine($"{i}: {shapeTypes[i].Name}");
        }
        selectedShapeIndex = int.Parse(Console.ReadLine());
        if (selectedShapeIndex < 0 || selectedShapeIndex >= shapeTypes.Count)
            throw new ArgumentException();
    }
    catch (ArgumentException argumentException)
    {
        Console.WriteLine("ERROR: There is no such shape. Select a number from the list");
        continue;
    }
    catch (Exception e)
    {
        Console.WriteLine("ERROR: Cant parse value. Use only numbers");
        continue;
    }
    selectedShapeType = shapeTypes[selectedShapeIndex];
    break;
}
        
var shapeBuilder = factory.BeginNewShape(selectedShapeType);
var parameterSetters = shapeBuilder.ParameterSetters().ToList();

for (int i = 0; i < parameterSetters.Count; i++)
{
    var parameterSetter = parameterSetters[i];
    var parameterName = parameterSetter.ParameterName;
    var newValueToSet = 0f;

    try
    {
        Console.WriteLine($"Print value for {shapeBuilder.ShapeName}'s parameter: {parameterName}");
        newValueToSet = float.Parse(Console.ReadLine());
    }
    catch (Exception e)
    {
        Console.WriteLine("ERROR: Cant parse value. Use only numbers");
        i--;
        continue;
    }
    parameterSetter.Set(newValueToSet);
}

IShape shape = shapeBuilder.EndNewShape();

Console.WriteLine($"Shape {shape.ShapeName} is created!");
//Console.WriteLine($"Shape {shape.ShapeName} has area of {shape.GetArea()}");