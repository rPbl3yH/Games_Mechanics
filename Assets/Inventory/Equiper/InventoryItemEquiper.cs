using Entities;
using Inventory.Components;
using Lessons.MetaGame.Inventory;

namespace Inventory.Equiper
{
    public class InventoryItemEquiper : IInventoryListener
    {
        private IEntity _player;

        public InventoryItemEquiper(IEntity entity)
        {
            _player = entity;
        }

        public void OnItemAdded(InventoryItem item)
        {
            if (item.Flags.HasFlag(InventoryItemFlags.EQUPPABLE))
            {
                var type = item.GetComponent<IComponent_Equipment>().Type;
                _player.Get<IComponent_EquipItem>().Equip(type);
            }
        }

        public void OnItemRemoved(InventoryItem item)
        {
            if (item.Flags.HasFlag(InventoryItemFlags.EQUPPABLE))
            {
                var type = item.GetComponent<IComponent_Equipment>().Type;
                _player.Get<IComponent_TakeOffItem>().TakeOff(type);
            }
        }
    }
}