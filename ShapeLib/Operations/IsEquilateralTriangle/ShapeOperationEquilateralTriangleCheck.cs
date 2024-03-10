namespace ShapeLib
{
    public class ShapeOperationEquilateralTriangleCheck : IShapeOperation, IShapeOperationExecuteCondition
    {
        public bool CanExecuteOn(IShape shape) => shape is IEquilateralTriangle;
        public void ExecuteOn(IShape shape)
        {
            if (!CanExecuteOn(shape)) throw new ArgumentException("Can not be executed");
            var equilateralTriangle = shape as IEquilateralTriangle;
            Result = equilateralTriangle.IsEquilateralTriangle();
        }
        public object Result { get; private set; }
    }
} 