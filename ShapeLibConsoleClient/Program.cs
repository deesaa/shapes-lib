new_shape:
Console.WriteLine("\n<><><><><><><><><><><><><><><><><><><><><><><><>\n");

ShapeLibClient shapeLibClient = new ShapeLibClient();

new_parameters:
shapeLibClient.SetParameters();

new_operation:
var result = shapeLibClient.OperationOverShape();

Console.WriteLine($">>>Result is {result}!<<<");

read_command_line:
Console.WriteLine($"Print 's' to create new shape");
Console.WriteLine($"Print 'o' to perform new operation");
Console.WriteLine($"Print 'p' to change shape parameters");
Console.WriteLine($"Print 'e' to exit");

var key = Console.ReadLine();

switch (key)
{
    case "s": goto new_shape;
    case "p": goto new_parameters;
    case "o": goto new_operation;
    case "e": goto exit;
    default: goto read_command_line;
}

exit:;