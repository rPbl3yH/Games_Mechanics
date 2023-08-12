using Game.App.Atomic.Values;

namespace Game.GamePlay.Conveyor.Components
{
    public interface IConveyor_SetLoadStorage
    {
        void SetLoadStorage(int value);
    }
    
    public class Conveyor_LoadComponent : IConveyor_SetLoadStorage 
    {
        private AtomicVariable<int> _value;

        public Conveyor_LoadComponent(AtomicVariable<int> value)
        {
            _value = value;
        }

        public void SetLoadStorage(int value)
        {
            _value.Value = value;
        }
    }
}