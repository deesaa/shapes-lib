namespace ShapeLib
{
    public class ValidGreaterThan : IParameterValidation
    {
        public static readonly ValidGreaterThan Zero = new ValidGreaterThan(0);

        private double _greaterThan;
        public ValidGreaterThan(double value)
        {
            _greaterThan = value;
        }

        public bool IsValid(double value) => value > _greaterThan;
        public void ThrowIfNotValid(double value)
        {
            if(IsValid(value)) return;
            throw new ArgumentException($"Parameter must be greater than {_greaterThan}, value was {value}");
        }
    }
}