namespace ShapeLib
{
    public class AlwaysValid : IParameterValidation
    {
        public static readonly AlwaysValid Instance = new AlwaysValid();
        public bool IsValid(float value) => true;
        public void ThrowIfNotValid(float value) { }
    }
}