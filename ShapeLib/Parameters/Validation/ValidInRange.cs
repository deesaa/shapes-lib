namespace ShapeLib
{
    public class ValidInRange : IParameterValidation
    {
        public static readonly ValidInRange Range0To180 = new ValidInRange(0, 180);

        private double _min;
        private double _max;
        public ValidInRange(double min, double max)
        {
            _min = min;
            _max = max;
        }

        public bool IsValid(double value) => value >= _min && value <= _max;
        public void ThrowIfNotValid(double value)
        {
            if(IsValid(value)) return;
            throw new ArgumentException($"Parameter must be in range between {_min} and {_max}, value was {value}");
        }
    }
}