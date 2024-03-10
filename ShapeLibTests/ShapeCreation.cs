using ShapeLib;

namespace ShapeLibTests
{
    public class ShapeCreation
    {
        private ShapeFactory _factory;
        [SetUp]
        public void Setup()
        {
            _factory = new ShapeFactory();
            _factory.AddShape<ShapeTriangle>();
            _factory.AddShape<ShapeCircle>();
        }

        [Test]
        public void GetListOfShapeTypes()
        {
            var typesCount = _factory.AvailableShapes().Count();
            Assert.That(typesCount, Is.EqualTo(2));
        }
    
        [Test]
        public void GetTriangleParametersCount()
        {
            int targetCount = 2;
        
            var triangleBuilder = _factory.BeginNewShape(typeof(ShapeTriangle));
            int count = triangleBuilder.ParameterSetters().Count();
            Assert.That(count, Is.EqualTo(targetCount));
        }
    }
}