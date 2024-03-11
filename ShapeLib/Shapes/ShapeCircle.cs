namespace ShapeLib
{
    public class ShapeCircle : IShape
    {
        private const string RadiusKey = "Radius";
        
        private static readonly Dictionary<string, ShapeParameter> Scheme = new() 
        {
            { RadiusKey, new ShapeParameter(0, ValidGreaterThan.Zero)} 
        };  
        
        private double _radius;
        private double _area;
        
        public IReadOnlyDictionary<string, ShapeParameter> ShapeParametersScheme => Scheme;
        public string ShapeName => GetType().Name;
        
        public void SetParameters(Dictionary<string, double> shapeParameters)
        {
            _radius = shapeParameters[RadiusKey];
            _area = MathF.PI * _radius * _radius;
        }

        public double GetArea() => _area;
    }
}