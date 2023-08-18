using System;
using System.Collections.Generic;
using Inventory.Components;
using Inventory.Equiper;
using Lessons.MetaGame.Inventory;

public class ListEquipment
{
    public Action<InventoryItem> OnEquipped;
    private readonly Dictionary<EquipmentType, InventoryItem> _equipments = new();
    private readonly EquipmentService _equipmentService;

    public ListEquipment(EquipmentService equipmentService)
    {
        _equipmentService = equipmentService;
    }

    public bool Equip(InventoryItem item)
    {
        var equipmentComponent = item.GetComponent<EquipmentComponent>();
        if (equipmentComponent is null)
        {
            return false;
        }

        if (!_equipmentService.CheckItem(item))
        {
            return false;
        }

        _equipments[equipmentComponent.Type] = item;
        OnEquipped?.Invoke(item);
        return true;
    }

    public InventoryItem GetItem(EquipmentType type)
    {
        _equipments.TryGetValue(type, out var item);
        return item;
    }
}