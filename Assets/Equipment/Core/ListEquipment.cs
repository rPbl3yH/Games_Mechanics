using System;
using System.Collections.Generic;
using Inventory.Components;
using Inventory.Equiper;
using Lessons.MetaGame.Inventory;

public class ListEquipment
{
    public Action<InventoryItem> OnEquipped;
    private readonly Dictionary<EquipmentType, InventoryItem> _equipments = new();
        
    public bool Equip(InventoryItem item)
    {
        var equipmentComponent = item.GetComponent<EquipmentComponent>();
        if (equipmentComponent is null)
        {
            return false;
        }

        _equipments[equipmentComponent.Type] = item;
        OnEquipped?.Invoke(item);
        return true;
    }
}