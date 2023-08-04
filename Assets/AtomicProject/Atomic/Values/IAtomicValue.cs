namespace AtomicProject.Atomic.Values
{
    public interface IAtomicValue<out T>
    {
        T Value { get; }
    }
}