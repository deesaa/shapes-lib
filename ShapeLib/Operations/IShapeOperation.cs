namespace ShapeLib
{
    public interface IShapeOperation
    {
        public void ExecuteOn(IShape shape);
        object Result { get; }
    }
}