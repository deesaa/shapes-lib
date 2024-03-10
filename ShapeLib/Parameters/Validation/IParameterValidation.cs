namespace ShapeLib
{
    public interface IParameterValidation
    {
        public bool IsValid(float value);
        void ThrowIfNotValid(float value);
    }
}