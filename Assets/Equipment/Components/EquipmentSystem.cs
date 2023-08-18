using System.Collections.Generic;
using Inventory.Equiper;
using Lessons.MetaGame.Inventory;

namespace Inventory.Components
{
    public class EquipmentSystem 
    {
        private readonly Dictionary<EquipmentType, InventoryItem> _equipments;

        public EquipmentSystem(Dictionary<EquipmentType, InventoryItem> equipments)
        {
            _equipments = equipments;
        }

        public void Equip(EquipmentType type, InventoryItem inventoryItem)
        {
            _equipments.TryAdd(type, inventoryItem);
        }

        public void TakeOff(EquipmentType type)
        {
            if (_equipments.ContainsKey(type))
            {
                _equipments.Remove(type);
            }
        }
    }
}