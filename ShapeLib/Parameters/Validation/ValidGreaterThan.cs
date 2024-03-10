namespace ShapeLib
{
    public class ValidGreaterThan : IParameterValidation
    {
        public static readonly ValidGreaterThan Zero = new ValidGreaterThan(0);

        private float _greaterThan;
        public ValidGreaterThan(float value)
        {
            _greaterThan = value;
        }

        public bool IsValid(float value) => value > _greaterThan;
        public void ThrowIfNotValid(float value)
        {
            if(IsValid(value)) return;
            throw new ArgumentException($"Parameter must be greater than {_greaterThan}, value was {value}");
        }
    }
}