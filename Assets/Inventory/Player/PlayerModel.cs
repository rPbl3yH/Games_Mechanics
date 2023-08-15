using System.Collections.Generic;
using AtomicProject.Atomic.Values;
using Declarative;
using Inventory.Equiper;
using Lessons.MetaGame.Inventory;
using Sirenix.OdinInspector;

namespace Inventory.Player
{
    public class PlayerModel : DeclarativeModel
    {
        public AtomicVariable<float> Damage;
        [ShowInInspector]
        public Dictionary<EquipmentType, InventoryItem> Equipments = new();
    }
}
