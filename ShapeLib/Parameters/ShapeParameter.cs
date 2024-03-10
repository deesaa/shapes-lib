namespace ShapeLib
{
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
}