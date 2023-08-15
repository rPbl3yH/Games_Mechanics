using Inventory.Equiper;
using Lessons.MetaGame.Inventory;

namespace Inventory.Components
{
    public interface IComponent_EquipItem
    {
        void Equip(EquipmentType type, InventoryItem inventoryItem);
    }
}