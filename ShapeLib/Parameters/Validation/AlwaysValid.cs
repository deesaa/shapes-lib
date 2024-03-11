namespace ShapeLib
{
    public class AlwaysValid : IParameterValidation
    {
        public static readonly AlwaysValid Instance = new AlwaysValid();
        public bool IsValid(double value) => true;
        public void ThrowIfNotValid(double value) { }
    }
}