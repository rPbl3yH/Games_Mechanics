using System.Collections.Generic;
using Inventory.Components;
using Inventory.Equiper;
using Lessons.MetaGame.Inventory;
using UnityEngine;

public class EquipmentService : IInventoryListener
{
    private readonly Dictionary<InventoryItem, EquipmentType> _availableItems = new();
        
    public bool CheckItem(EquipmentType type)
    {
        return FindItem(type);
    }

    private bool FindItem(EquipmentType type)
    {
        foreach (var pair in _availableItems)
        {
            if (pair.Value == type)
            {
                return true;
            }
        }

        return false;
    }

    public void OnItemAdded(InventoryItem item)
    {
        if (!item.Flags.HasFlag(InventoryItemFlags.EQUPPABLE))
        {
            return;
        }
            
        var type = item.GetComponent<EquipmentComponent>().Type;

        if (_availableItems.TryAdd(item, type))
        {
                   
        }
        else
        {
            Debug.Log("Don't add to available items " + item.Name);
        }
    }

    public void OnItemRemoved(InventoryItem item)
    {
            
    }
}