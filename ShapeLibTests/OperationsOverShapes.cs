using ShapeLib;

namespace ShapeLibTests
{
    public class OperationsOverShapes
    {
        private ShapeFactory _factory;
        private IShape _circleShape;
        private IShape _triangleShape;

        private const float Tolerance = 0.001f; 

        private const float TriangleEdge = 5f; 
        private const float TriangleAreaExpected = 12.5f; 
    
        private const float CircleRadius = 5f; 
        private const float CircleAreaExpected = 78.53982f; 
    
        [SetUp]
        public void Setup()
        {
            _factory = new ShapeFactory();
            _factory.AddShape<ShapeTriangle>();
            _factory.AddShape<ShapeCircle>();
        
            var shapeBuilder = _factory.BeginNewShape(typeof(ShapeTriangle));
            foreach (var shapeParameterSetter in shapeBuilder.ParameterSetters())
                shapeParameterSetter.Set(TriangleEdge);
            _triangleShape = shapeBuilder.EndNewShape();
        
            shapeBuilder = _factory.BeginNewShape(typeof(ShapeCircle));
            foreach (var shapeParameterSetter in shapeBuilder.ParameterSetters())
                shapeParameterSetter.Set(CircleRadius);
            _circleShape = shapeBuilder.EndNewShape();
        }
    
        [Test]
        public void CircleArea()
        {
            var operation = new ShapeOperationArea();
            operation.ExecuteOn(_circleShape);
            var area = (float)operation.Result;
            Assert.That(area, Is.EqualTo(CircleAreaExpected).Within(Tolerance));
        }
        
        [Test]
        public void IsTriangleRight()
        {
            var operation = new ShapeOperationRightTriangleCheck();
            operation.ExecuteOn(_triangleShape);
            var isRight  = (bool)operation.Result;
            Assert.That(isRight, Is.True);
        }
        
        [Test]
        public void CanExecuteAreaOnShapes()
        {
            var operation = new ShapeOperationArea();
            var canExecuteOnCircle = operation.CanExecuteOn(_circleShape);
            var canExecuteOnTriangle = operation.CanExecuteOn(_triangleShape);
            Assert.That(canExecuteOnCircle, Is.True);
            Assert.That(canExecuteOnTriangle, Is.True);
        }
        
        [Test]
        public void CanExecuteEquilateralTriangleOnShapes()
        {
            var operation = new ShapeOperationEquilateralTriangleCheck();
            var canExecuteOnCircle = operation.CanExecuteOn(_circleShape);
            var canExecuteOnTriangle = operation.CanExecuteOn(_triangleShape);
            Assert.That(canExecuteOnCircle, Is.False);
            Assert.That(canExecuteOnTriangle, Is.True);
        }
    
        [Test]
        public void TriangleArea()
        {
            var operation = new ShapeOperationArea();
            operation.ExecuteOn(_triangleShape);
            var area = (float)operation.Result;
            Assert.That(area, Is.EqualTo(TriangleAreaExpected).Within(Tolerance));
        }
    }
}