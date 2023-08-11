namespace Game.App.Atomic.Values
{
    public interface IAtomicValue<out T>
    {
        T Value { get; }
    }
}