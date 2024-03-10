namespace ShapeLib
{
    public class ShapeCircle : IShape, IArea
    {
        private const string RadiusKey = "Radius";
        
        private static readonly Dictionary<string, ShapeParameter> Scheme = new() 
        {
            { RadiusKey, new ShapeParameter(0, ValidGreaterThan.Zero)} 
        };  
        
        private float _radius;
        private float _area;
        
        public IReadOnlyDictionary<string, ShapeParameter> ShapeParametersScheme => Scheme;
        public string ShapeName => GetType().Name;
        
        public void SetParameters(Dictionary<string, float> shapeParameters)
        {
            _radius = shapeParameters[RadiusKey];
            _area = MathF.PI * _radius * _radius;
        }

        public float GetArea() => _area;
    }
}