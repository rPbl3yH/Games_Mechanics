using AtomicProject.Atomic.Values;
using Declarative;

namespace Game
{
    public class PlayerModel : DeclarativeModel
    {
        public AtomicVariable<int> IitPoints;
        public AtomicVariable<int> Damage;
        public AtomicVariable<float> Speed;
    }
}
