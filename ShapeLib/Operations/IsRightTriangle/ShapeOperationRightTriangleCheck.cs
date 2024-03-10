namespace ShapeLib
{
    public class ShapeOperationRightTriangleCheck : IShapeOperation, IShapeOperationExecuteCondition
    {
        public bool CanExecuteOn(IShape shape) => shape is IRightTriangle;
        public void ExecuteOn(IShape shape)
        {
            if (!CanExecuteOn(shape)) throw new ArgumentException("Can not be executed");
            var isRight = shape as IRightTriangle;
            Result = isRight.IsRightTriangle();
        }
        public object Result { get; private set; }
    }
}