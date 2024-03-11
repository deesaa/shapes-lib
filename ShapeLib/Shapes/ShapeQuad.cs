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
        
        private float _sideA;
        private float _sideB;
        private float _area;
        
        public IReadOnlyDictionary<string, ShapeParameter> ShapeParametersScheme => Scheme;
        public string ShapeName => GetType().Name;
        
        public void SetParameters(Dictionary<string, float> shapeParameters)
        {
            _sideA = shapeParameters[SideA];
            _sideB = shapeParameters[SideB];
            _area = _sideA * _sideB;
        }
        public float GetArea() => _area;
    }
}