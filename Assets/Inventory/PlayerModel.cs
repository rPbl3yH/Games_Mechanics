using AtomicProject.Atomic.Values;
using Declarative;
using UnityEngine;

namespace Game
{
    public class PlayerModel : DeclarativeModel
    {
        [SerializeField]
        public AtomicVariable<int> HitPoints;
        [SerializeField]
        public AtomicVariable<float> Damage;
        [SerializeField]
        public AtomicVariable<float> Speed;
    }
}
