namespace ShapeLib
{
    public interface IShapeOperationExecuteCondition
    {
        public bool CanExecuteOn(IShape shape);
    }
}