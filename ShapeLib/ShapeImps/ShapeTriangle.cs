using System.Collections;

namespace ShapeLib;

public interface IParameterValidation
{
    public bool IsValid(float value);
    void ThrowIfNotValid(float value);
}

public class AlwaysValid : IParameterValidation
{
    public static readonly AlwaysValid Instance = new AlwaysValid();
    public bool IsValid(float value) => true;
    public void ThrowIfNotValid(float value) { }
}

public class ValidGreaterThan : IParameterValidation
{
    public static readonly ValidGreaterThan Zero = new ValidGreaterThan(0);

    private float _greaterThan;
    public ValidGreaterThan(float value)
    {
        _greaterThan = value;
    }

    public bool IsValid(float value) => value > _greaterThan;
    public void ThrowIfNotValid(float value)
    {
        if(IsValid(value)) return;
        throw new ArgumentException($"Parameter must be greater than {_greaterThan}, value was {value}");
    }
}

public class ShapeParameter
{
    public float DefaultValue { get; }
    public IParameterValidation Validation { get; }

    public ShapeParameter(float defaultValue, IParameterValidation validation)
    {
        DefaultValue = defaultValue;
        Validation = validation;
    }
}



public class ShapeTriangle : IShape, IRightTriangle
{
    private const float Tolerance = float.Epsilon;
    
    private const string SideSizeAKey = "Length of the side A";
    private const string SideSizeBKey = "Length of the side B";
    
    private static readonly Dictionary<string, ShapeParameter> Scheme = new() 
    {
        { SideSizeAKey, new ShapeParameter(0, ValidGreaterThan.Zero)},
        { SideSizeBKey, new ShapeParameter(0, ValidGreaterThan.Zero) },
    };

    private float _sideSizeA;
    private float _sideSizeB;
    private float _sideSizeC;
    
    private float _area;
    private bool _isRightTriangle;
    
    public string ShapeName => GetType().Name;
    public IReadOnlyDictionary<string, ShapeParameter> ShapeParametersScheme => Scheme;

    public void SetParameters(Dictionary<string, float> shapeParameters)
    {
        _sideSizeA = shapeParameters[SideSizeAKey];
        _sideSizeB = shapeParameters[SideSizeBKey];
        _sideSizeC = MathF.Sqrt(_sideSizeA * _sideSizeA + _sideSizeB * _sideSizeB);
        
        var p = (_sideSizeA + _sideSizeB + _sideSizeC) / 2;
        _area = MathF.Sqrt(p * (p - _sideSizeA) * (p - _sideSizeB) * (p - _sideSizeC));
        
        _isRightTriangle = Math.Abs(_sideSizeA - _sideSizeB) < Tolerance &&
                           Math.Abs(_sideSizeB - _sideSizeC) < Tolerance && 
                           Math.Abs(_sideSizeC - _sideSizeA) < Tolerance;
    }
    
    public float GetArea() => _area;
    
    public bool IsRightTriangle() => _isRightTriangle;
}