namespace ShapeLib
{
    public interface IShapeOperationExecuteCondition
    {
        public bool CanExecuteOn(IShape shape);
    }
    
    public interface IShapeOperation
    {
        public void ExecuteOn(IShape shape);
        object Result { get; }
    }
}