﻿using System.Collections;

namespace ShapeLib;

public class ShapeTriangle : IShape, ITriangle
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
    private bool _isEquilateralTriangle;
    
    public string ShapeName => GetType().Name;
    public IReadOnlyDictionary<string, ShapeParameter> ShapeParametersScheme => Scheme;

    public void SetParameters(Dictionary<string, float> parameters)
    {
        _sideSizeA = parameters[SideSizeAKey];
        _sideSizeB = parameters[SideSizeBKey];
        _sideSizeC = MathF.Sqrt(_sideSizeA * _sideSizeA + _sideSizeB * _sideSizeB);
        
        var p = (_sideSizeA + _sideSizeB + _sideSizeC) / 2;
        _area = MathF.Sqrt(p * (p - _sideSizeA) * (p - _sideSizeB) * (p - _sideSizeC));
        
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
    
    public float GetArea() => _area;
    public bool IsRightTriangle() => _isRightTriangle;
    public bool IsEquilateralTriangle() => _isEquilateralTriangle;
}