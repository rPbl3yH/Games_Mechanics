using System.Collections.Generic;
using Inventory.Equiper;
using Lessons.MetaGame.Inventory;

namespace Inventory.Components
{
    class ComponentEquipItem : IComponent_EquipItem
    {
        private readonly Dictionary<EquipmentType, InventoryItem> _equipments;

        public ComponentEquipItem(Dictionary<EquipmentType, InventoryItem> equipments)
        {
            _equipments = equipments;
        }

        public void Equip(EquipmentType type, InventoryItem inventoryItem)
        {
            _equipments.TryAdd(type, inventoryItem);
        }
    }
}