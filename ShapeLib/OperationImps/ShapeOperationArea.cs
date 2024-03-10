namespace ShapeLib
{
    public class ShapeOperationArea : IShapeOperation, IShapeOperationExecuteCondition
    {
        public bool CanExecuteOn(IShape shape) => shape is IArea area;
        public void ExecuteOn(IShape shape)
        {
            if (!CanExecuteOn(shape)) throw new ArgumentException("Can not be executed");
            var area = shape as IArea;
            Result = area.GetArea();
        }
        public object Result { get; private set; }
    }
}