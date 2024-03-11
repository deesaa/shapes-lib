namespace ShapeLib
{
    public interface IParameterValidation
    {
        public bool IsValid(double value);
        void ThrowIfNotValid(double value);
    }
}