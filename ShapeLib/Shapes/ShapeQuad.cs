namespace ShapeLib
{
    public class ShapeQuad : IShape, IArea
    {
        private const string SideA = "SideA";
        private const string SideB = "SideB";
        
        private static readonly Dictionary<string, ShapeParameter> Scheme = new() 
        {
            { SideA, new ShapeParameter(0, ValidGreaterThan.Zero)},
            { SideB, new ShapeParameter(0, ValidGreaterThan.Zero)} 
        };  
        
        private double _sideA;
        private double _sideB;
        private double _area;
        
        public IReadOnlyDictionary<string, ShapeParameter> ShapeParametersScheme => Scheme;
        public string ShapeName => GetType().Name;
        
        public void SetParameters(Dictionary<string, double> shapeParameters)
        {
            _sideA = shapeParameters[SideA];
            _sideB = shapeParameters[SideB];
            _area = _sideA * _sideB;
        }
        public double GetArea() => _area;
    }
}