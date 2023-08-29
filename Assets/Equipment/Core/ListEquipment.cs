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
    
        public void Equip(EquipmentType type, InventoryItem item)
        {
            _equipments[type] = item;
            OnEquipped?.Invoke(item);
            Debug.Log("Equip " + item);
        }

        public void Unequip(EquipmentType type)
        {
            _equipments.Remove(type);
            Debug.Log("Unequip " + type);
        }

        public bool HasItem(InventoryItem item)
        {
            return _equipments.ContainsValue(item);
        }

        public InventoryItem GetItem(EquipmentType type)
        {
            _equipments.TryGetValue(type, out var item);
            return item;
        }
    }
}