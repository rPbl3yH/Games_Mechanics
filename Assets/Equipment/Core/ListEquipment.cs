using System.Collections.Generic;
using Inventory.Components;
using Inventory.Equiper;
using Lessons.MetaGame.Inventory;

public class ListEquipment
{
    private readonly Dictionary<EquipmentType, InventoryItem> _equipments = new();
        
    public bool Equip(InventoryItem legsItem)
    {
        var component = legsItem.GetComponent<EquipmentComponent>();
        if (component is null)
        {
            return false;
        }

        _equipments[component.Type] = legsItem;
        return true;
    }
}