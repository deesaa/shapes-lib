using ShapeLib;

namespace ShapeLibTests
{
    public class OperationsOverShapes
    {
        private ShapeFactory _factory;
        private IShape _circleShape;
        private IShape _triangleShape;
        private IShape _notRightTriangleShape;

        private const float Tolerance = 0.001f; 

        private const float RightTriangleEdge1 = 3f; 
        private const float RightTriangleEdge2 = 4f; 
        private const float TriangleAreaExpected = 6f; 
    
        private const float CircleRadius = 5f; 
        private const float CircleAreaExpected = 78.53982f; 
        
        private const float NotRightTriangleEdge1 = 15f; 
        private const float NotRightTriangleEdge2 = 30f; 
    
        [SetUp]
        public void Setup()
        {
            _factory = new ShapeFactory();
            _factory.AddShape<ShapeTriangle>();
            _factory.AddShape<ShapeCircle>();
        
            var shapeBuilder = _factory.BeginNewShape(typeof(ShapeTriangle));
            var parameters = shapeBuilder.ParameterSetters().ToList();
            parameters[0].Set(RightTriangleEdge1);
            parameters[1].Set(RightTriangleEdge2);
            _triangleShape = shapeBuilder.EndNewShape();
        
            shapeBuilder = _factory.BeginNewShape(typeof(ShapeCircle));
            foreach (var shapeParameterSetter in shapeBuilder.ParameterSetters())
                shapeParameterSetter.Set(CircleRadius);
            _circleShape = shapeBuilder.EndNewShape();
            
            shapeBuilder = _factory.BeginNewShape(typeof(ShapeTriangle));
            parameters = shapeBuilder.ParameterSetters().ToList();
            parameters[0].Set(NotRightTriangleEdge1);
            parameters[1].Set(NotRightTriangleEdge2);
            _notRightTriangleShape = shapeBuilder.EndNewShape();
        }
    
        [Test]
        public void CircleArea()
        {
            var operation = new ShapeOperationArea();
            operation.ExecuteOn(_circleShape);
            var area = (double)operation.Result;
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
        public void IsTriangleNotRight()
        {
            var operation = new ShapeOperationRightTriangleCheck();
            operation.ExecuteOn(_notRightTriangleShape);
            var isRight  = (bool)operation.Result;
            Assert.That(isRight, Is.False);
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
            var area = (double)operation.Result;
            Assert.That(area, Is.EqualTo(TriangleAreaExpected).Within(Tolerance));
        }
    }
}