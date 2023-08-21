using Inventory.Equiper;
using Lessons.MetaGame.Inventory;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

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
        public void DebugEquip()
        {
            _listInventory.FindItem("boots", out var result);
            _equipment.Equip(result);
        }
    }
}