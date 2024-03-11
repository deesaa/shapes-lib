namespace ShapeLib
{
    public interface IShape : IArea
    {
        public string ShapeName { get; }
        public IReadOnlyDictionary<string, ShapeParameter> ShapeParametersScheme { get; }
       // public void SetParameters(Dictionary<string, float> shapeParameters);
        void SetParameters(Dictionary<string, double> parameters);
    }
}