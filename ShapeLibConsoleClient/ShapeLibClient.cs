using ShapeLib;
using ShapeLibConsoleClient;

public class ShapeLibClient
{
    private ShapeFactory _shapes;
    private ShapeOperationsFactory _operationsFactory;
    
    private IShape _currentShape;
    private Type _currentShapeType;
    
    public ShapeLibClient()
    {
        _shapes = ShapeLibClientConfig.CreateShapeFactory();
        _operationsFactory = ShapeLibClientConfig.CreateOperationsFactory();
        CreateShape();
    }

    public void CreateShape()
    {
        var shapeTypes = _shapes.AvailableShapes().ToList();
        
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
            _currentShapeType = shapeTypes[selectedShapeIndex];
            break;
        }
    }
    
    public object OperationOverShape()
    {
        var operationList = _operationsFactory.AvailableFor(_currentShape).ToList();
        IShapeOperation selectedOperation = null;

        while (true)
        {
            var selectedOperationIndex = -1;
            try
            {
                Console.WriteLine("Print a number from the list to select a type of the Operation");
                for (int i = 0; i < operationList.Count; i++)
                {
                    Console.WriteLine($"{i}: {operationList[i].Name}");
                }
                selectedOperationIndex = int.Parse(Console.ReadLine());
                if (selectedOperationIndex < 0 || selectedOperationIndex >= operationList.Count)
                    throw new ArgumentException();
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine("ERROR: There is no such operation. Select a number from the list");
                continue;
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: Cant parse value. Use only numbers");
                continue;
            }

            selectedOperation = _operationsFactory.GetOperation(operationList[selectedOperationIndex]);
            break;
        }

        selectedOperation.ExecuteOn(_currentShape);
        var operationResult = selectedOperation.Result;
        return operationResult;
    }

    public void SetParameters()
    {
        var shapeBuilder = _shapes.BeginNewShape(_currentShapeType);
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
                parameterSetter.Set(newValueToSet);
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine(argumentException.Message);
                i--;
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: Cant parse value. Use only numbers");
                i--;
            }
        }
        
        _currentShape = shapeBuilder.EndNewShape();
    }
}