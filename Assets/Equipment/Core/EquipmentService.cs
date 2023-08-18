using System.Collections.Generic;
using Entities;
using Inventory.Components;
using Inventory.Equiper;
using Lessons.MetaGame.Inventory;
using UnityEngine;

public class EquipmentService
{
    private ListInventory _listInventory;

    public EquipmentService(ListInventory listInventory)
    {
        _listInventory = listInventory;
    }

    public bool CheckItem(InventoryItem equipmentItem)
    {
        return _listInventory.GetItems().Contains(equipmentItem);
    }

    public bool FindItem(EquipmentType type, out InventoryItem result)
    {
        result = null;
        
        foreach (var item in _listInventory.GetItems())
        {
            var component = item.GetComponent<EquipmentComponent>(); 
            if (component.Type == type)
            {
                result = item;
                return true;
            }
        }
        return false;
    }

    public InventoryItem GetItem(EquipmentType type)
    {
        if (FindItem(type, out var result))
        {
            return result;
        }

        return null;
    }
}