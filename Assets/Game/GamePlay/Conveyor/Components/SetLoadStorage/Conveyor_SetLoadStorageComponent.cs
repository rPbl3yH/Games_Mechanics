using Game.App.Atomic.Values;

namespace Game.GamePlay.Conveyor.Components
{
    public class Conveyor_SetLoadStorageComponent : IConveyor_SetLoadStorageComponent 
    {
        private readonly AtomicVariable<int> _loadStorage;

        public Conveyor_SetLoadStorageComponent(AtomicVariable<int> loadStorage)
        {
            _loadStorage = loadStorage;
        }

        public void SetLoadStorage(int value)
        {
            _loadStorage.Value = value;
        }
    }
}