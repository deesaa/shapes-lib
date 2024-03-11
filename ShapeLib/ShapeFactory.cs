namespace ShapeLib
{
    public class ShapeFactory
    {
        private Dictionary<Type, Func<IShape>> _shapeFactories = new();
        public void AddShape<T>() where T : IShape, new()
        {
            _shapeFactories.TryAdd(typeof(T), () => new T());
        }

        public ShapeBuilder BeginNewShape(Type type) => new(_shapeFactories[type]);

        public class ShapeBuilder
        {
            private IShape _newShape;
            private Dictionary<string, double> _newValues;
            
            private int _parametersToSet;
            public string ShapeName => _newShape.ShapeName;

            internal ShapeBuilder(Func<IShape> shapeBuilder)
            {
                _newShape = shapeBuilder();
                _newValues = new();
                _parametersToSet = _newShape.ShapeParametersScheme.Count;
            }

            public IEnumerable<ShapeParameterSetter> ParameterSetters()
            {
                foreach (var parameter in _newShape.ShapeParametersScheme)
                {
                    yield return new ShapeParameterSetter(parameter.Key, 
                        newValue => OnNewParameterSet(parameter.Key, newValue));
                }
            }

            private void OnNewParameterSet(string key, double value)
            {
                _newShape.ShapeParametersScheme[key].Validation.ThrowIfNotValid(value);
                
                _newValues[key] = value;
                _parametersToSet--;
            }

            public IShape EndNewShape()
            {
                if (_parametersToSet != 0) 
                    throw new InvalidOperationException($"Now all parameters are set, remains {_parametersToSet}");
                
                _newShape.SetParameters(_newValues);
                return _newShape;
            }
        }

        public class ShapeParameterSetter
        {
            public string ParameterName { get; set; }
            private Action<double> _valueSetObserver;

            internal ShapeParameterSetter(string parameterName, Action<double> valueSetObserver)
            {
                ParameterName = parameterName;
                _valueSetObserver = valueSetObserver;
            }

            public void Set(double newValue)
            {
                _valueSetObserver(newValue);
            }
        }

        public IEnumerable<Type> AvailableShapes()
        {
            foreach (var shapeFactory in _shapeFactories)
            {
                yield return shapeFactory.Key;
            }
        }
    }
}