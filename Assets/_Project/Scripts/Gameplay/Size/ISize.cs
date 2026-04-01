public interface ISize
{
    public event System.Action<float> sizeChanged;

    public float StartSize { get; }
}
