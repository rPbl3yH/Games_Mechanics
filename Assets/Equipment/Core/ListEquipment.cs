using System.Collections.Generic;
using Inventory.Components;
using Inventory.Equiper;
using Lessons.MetaGame.Inventory;

public class ListEquipment
{
    private readonly Dictionary<EquipmentType, InventoryItem> _equipments = new();
        
    public bool CanEquip(InventoryItem legsItem)
    {
        var type = legsItem.GetComponent<EquipmentComponent>().Type;
        return _equipments.TryAdd(type, legsItem);
    }
}