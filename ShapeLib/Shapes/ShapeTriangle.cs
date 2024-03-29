﻿using System.Collections;

namespace ShapeLib;

public class ShapeTriangle : ITriangle
{
    private const double Tolerance = 0.00001d;
    
    public const string SideSizeAKey = "Length of the side A";
    public const string SideSizeBKey = "Length of the side B";
    public const string AngleDegreesAB = "Angle between A and B in degrees";
    
    private static readonly Dictionary<string, ShapeParameter> Scheme = new() 
    {
        { SideSizeAKey, new ShapeParameter(0, ValidGreaterThan.Zero)},
        { SideSizeBKey, new ShapeParameter(0, ValidGreaterThan.Zero) },
        { AngleDegreesAB, new ShapeParameter(0, ValidInRange.Range0To180) },
    };

    private double _sideSizeA;
    private double _sideSizeB;
    private double _sideSizeC;
    
    private double _area;
    private bool _isRightTriangle;
    private bool _isEquilateralTriangle;
    
    public string ShapeName => GetType().Name;
    public IReadOnlyDictionary<string, ShapeParameter> ShapeParametersScheme => Scheme;

    public void SetParameters(Dictionary<string, double> parameters)
    {
        _sideSizeA = parameters[SideSizeAKey];
        _sideSizeB = parameters[SideSizeBKey];

        double angleDegrees = parameters[AngleDegreesAB];
        double radians = (Math.PI / 180) * angleDegrees;
        var x = 2 * _sideSizeA * _sideSizeB * Math.Cos(radians);
        _sideSizeC = Math.Sqrt(_sideSizeA * _sideSizeA + _sideSizeB * _sideSizeB - x);
        
        var p = (_sideSizeA + _sideSizeB + _sideSizeC) / 2;
        _area = Math.Sqrt(p * (p - _sideSizeA) * (p - _sideSizeB) * (p - _sideSizeC));
        
        _isEquilateralTriangle = Math.Abs(_sideSizeA - _sideSizeB) < Tolerance &&
                                 Math.Abs(_sideSizeB - _sideSizeC) < Tolerance && 
                                 Math.Abs(_sideSizeC - _sideSizeA) < Tolerance;

        _isRightTriangle = Math.Abs(_sideSizeA * _sideSizeA + _sideSizeB * _sideSizeB - _sideSizeC * _sideSizeC) <
                           Tolerance ||
                           Math.Abs(_sideSizeA * _sideSizeA + _sideSizeC * _sideSizeC - _sideSizeB * _sideSizeB) <
                           Tolerance ||
                           Math.Abs(_sideSizeB * _sideSizeB + _sideSizeC * _sideSizeC - _sideSizeA * _sideSizeA) <
                           Tolerance;
    }
    
    public double GetArea() => _area;
    public bool IsRightTriangle() => _isRightTriangle;
    public bool IsEquilateralTriangle() => _isEquilateralTriangle;
}