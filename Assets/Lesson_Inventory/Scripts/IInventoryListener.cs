namespace Lessons.MetaGame.Inventory
{
    public interface IInventoryListener
    {
        void OnItemAdded(InventoryItem item);
        void OnItemRemoved(InventoryItem item);
    }
}

