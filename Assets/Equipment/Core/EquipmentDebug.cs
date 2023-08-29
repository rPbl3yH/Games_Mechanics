using Inventory.Equiper;
using Lessons.MetaGame.Inventory;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace Equipment.Core
{
    public class EquipmentDebug : MonoBehaviour
    {
        [Inject]
        [ShowInInspector] 
        private ListInventory _listInventory;
        
        [Inject]
        [ShowInInspector]
        private InventoryItemEquipment _equipment;

        [Button]
        public void AddInventoryItem(InventoryItemConfig config)
        {
            _listInventory.AddItem(config.item.Clone());
        }
        
        [Button]
        public void DebugEquip(InventoryItemConfig config)
        {
            _listInventory.FindItem(config.item.Name, out var result);
            _equipment.Equip(result);
        }

        [Button]
        public void DebugUnequip(InventoryItemConfig config)
        {
            _listInventory.FindItem(config.item.Name, out var result);
            _equipment.Unequip(result);
        }
    }
}