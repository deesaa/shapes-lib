using ShapeLib;

namespace ShapeLibTests
{
    public class OperationsOverShapes
    {
        private ShapeFactory _factory;
        private IShape _circleShape;
        private IShape _triangleShape;
        private IShape _notRightTriangleShape;

        private const double RightTriangleEdge1 = 3d; 
        private const double RightTriangleEdge2 = 4d; 
        private const double RightTriangleAngle = 90d; 
        private const double TriangleAreaExpected = 6d; 
    
        private const double CircleRadius = 5d; 
        private const double CircleAreaExpected = 78.5398163397d; 
        private const double Tolerance = 0.00001d; 

        
        private const double NotRightTriangleEdge1 = 3d; 
        private const double NotRightTriangleEdge2 = 4d; 
        private const double NotRightTriangleAngle = 89d; 
    
        [SetUp]
        public void Setup()
        {
            _factory = new ShapeFactory();
            _factory.AddShape<ShapeTriangle>();
            _factory.AddShape<ShapeCircle>();
        
            //Triangle
            var shapeBuilder = _factory.BeginNewShape(typeof(ShapeTriangle));
            var parameters = shapeBuilder
                .ParameterSetters()
                .ToDictionary(x => x.ParameterName, x => x);
            
            parameters[ShapeTriangle.SideSizeAKey].Set(RightTriangleEdge1);
            parameters[ShapeTriangle.SideSizeBKey].Set(RightTriangleEdge2);
            parameters[ShapeTriangle.AngleDegreesAB].Set(RightTriangleAngle);
            _triangleShape = shapeBuilder.EndNewShape();
        
            //Circle
            shapeBuilder = _factory.BeginNewShape(typeof(ShapeCircle));
            parameters = shapeBuilder
                .ParameterSetters()
                .ToDictionary(x => x.ParameterName, x => x);
            parameters[ShapeCircle.RadiusKey].Set(CircleRadius);
            _circleShape = shapeBuilder.EndNewShape();
            
            //Triangle
            shapeBuilder = _factory.BeginNewShape(typeof(ShapeTriangle));
            parameters = shapeBuilder
                .ParameterSetters()
                .ToDictionary(x => x.ParameterName, x => x);
            
            parameters[ShapeTriangle.SideSizeAKey].Set(NotRightTriangleEdge1);
            parameters[ShapeTriangle.SideSizeBKey].Set(NotRightTriangleEdge2);
            parameters[ShapeTriangle.AngleDegreesAB].Set(NotRightTriangleAngle);
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