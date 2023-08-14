using Entities;
using Lessons.MetaGame.Inventory;
using UnityEngine;

public class InventoryItemEquiper : IInventoryListener
{
    private IEntity _player;

    public InventoryItemEquiper(IEntity entity)
    {
        _player = entity;
    }

    public void OnItemAdded(InventoryItem item)
    {
        if (item.Flags.HasFlag(InventoryItemFlags.EQUPPABLE))
        {
            var type = item.GetComponent<IComponent_Equipment>().Type;
            _player.Get<IComponent_SetEquipment>().Equip(type);
        }
    }

    public void OnItemRemoved(InventoryItem item)
    {
        
    }
}