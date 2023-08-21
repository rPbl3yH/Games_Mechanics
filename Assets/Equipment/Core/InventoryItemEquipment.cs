using Entities;
using Equipment.Core;
using Inventory.Components;
using Lessons.MetaGame.Inventory;
using Zenject;

namespace Inventory.Equiper
{
    public class InventoryItemEquipment
    {
        private readonly ListInventory _listInventory;
        private readonly ListEquipment _listEquipment;
        
        [Inject]
        public InventoryItemEquipment(ListEquipment listEquipment, ListInventory listInventory)
        {
            _listEquipment = listEquipment;
            _listInventory = listInventory;
        }

        public bool Equip(InventoryItem item)
        {
            var equipmentComponent = item.GetComponent<EquipmentComponent>();
            if (equipmentComponent is null)
            {
                return false;
            }

            if (!_listInventory.CheckItem(item))
            {
                return false;
            }

            _listEquipment.Equip(equipmentComponent.Type, item);
            return true;
        }
    }
}