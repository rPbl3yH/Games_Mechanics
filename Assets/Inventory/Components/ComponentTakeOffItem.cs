using System.Collections.Generic;
using Inventory.Equiper;
using Lessons.MetaGame.Inventory;

namespace Inventory.Components
{
    class ComponentTakeOffItem : IComponent_TakeOffItem
    {
        private readonly Dictionary<EquipmentType, InventoryItem> _equipments;

        public ComponentTakeOffItem(Dictionary<EquipmentType, InventoryItem> equipments)
        {
            _equipments = equipments;
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