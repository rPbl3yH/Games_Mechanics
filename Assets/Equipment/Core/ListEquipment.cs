using System;
using System.Collections.Generic;
using Inventory.Equiper;
using Lessons.MetaGame.Inventory;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Equipment.Core
{
    public class ListEquipment
    {
        public Action<InventoryItem> OnEquipped;
    
        [ShowInInspector]
        private readonly Dictionary<EquipmentType, InventoryItem> _equipments = new();
    
        public bool Equip(EquipmentType type, InventoryItem item)
        {
            _equipments[type] = item;
            OnEquipped?.Invoke(item);
            Debug.Log("Equip " + item);
            return true;
        }

        public InventoryItem GetItem(EquipmentType type)
        {
            _equipments.TryGetValue(type, out var item);
            return item;
        }
    }
}