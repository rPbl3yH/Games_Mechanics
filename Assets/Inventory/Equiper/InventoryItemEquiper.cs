using Entities;
using Inventory.Components;
using Lessons.MetaGame.Inventory;

namespace Inventory.Equiper
{
    public class InventoryItemEquiper : IInventoryListener
    {
        private readonly IEntity _entity;

        public InventoryItemEquiper(IEntity entity)
        {
            _entity = entity;
        }

        public void OnItemAdded(InventoryItem item)
        {
            if (item.Flags.HasFlag(InventoryItemFlags.EQUPPABLE))
            {
                var type = item.GetComponent<IComponent_Equipment>().Type;
                _entity.Get<IComponent_EquipItem>().Equip(type, item);
            }
        }

        public void OnItemRemoved(InventoryItem item)
        {
            if (item.Flags.HasFlag(InventoryItemFlags.EQUPPABLE))
            {
                var type = item.GetComponent<IComponent_Equipment>().Type;
                _entity.Get<IComponent_TakeOffItem>().TakeOff(type);
            }
        }
    }
}