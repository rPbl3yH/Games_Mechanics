using AtomicProject.Atomic.Values;
using UnityEngine;

namespace Inventory.Player
{
    public class PlayerModel : MonoBehaviour
    {
        public AtomicVariable<float> Damage = new();
    }
}
