namespace ShapeLib
{
    public class ShapeParameter
    {
        public double DefaultValue { get; }
        public IParameterValidation Validation { get; }

        public ShapeParameter(double defaultValue, IParameterValidation validation)
        {
            DefaultValue = defaultValue;
            Validation = validation;
        }
    }
}