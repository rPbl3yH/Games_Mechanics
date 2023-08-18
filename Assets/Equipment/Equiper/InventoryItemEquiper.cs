using Entities;
using Inventory.Components;
using Lessons.MetaGame.Inventory;

namespace Inventory.Equiper
{
    public class InventoryItemEquiper : IInventoryListener
    {
        private readonly IEntity _entity;
        private readonly EquipmentSystem _equipmentSystem;
        
        public InventoryItemEquiper(IEntity entity)
        {
            _entity = entity;
        }

        public void OnItemAdded(InventoryItem item)
        {
            if (item.Flags.HasFlag(InventoryItemFlags.EQUPPABLE))
            {
                var type = item.GetComponent<IComponent_Equipment>().Type;
                _equipmentSystem.Equip(type,item);
            }
        }

        public void OnItemRemoved(InventoryItem item)
        {
            if (item.Flags.HasFlag(InventoryItemFlags.EQUPPABLE))
            {
                var type = item.GetComponent<IComponent_Equipment>().Type;
                _equipmentSystem.TakeOff(type);
            }
        }
    }
}