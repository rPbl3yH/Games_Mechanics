using System.Collections.Generic;
using System.Linq;
using Inventory.Components;
using Inventory.Equiper;
using Sirenix.OdinInspector;

namespace Lessons.MetaGame.Inventory
{
    public sealed class ListInventory
    {
        [ShowInInspector, ReadOnly]
        private readonly List<InventoryItem> items;
        private readonly List<IInventoryListener> observers = new();

        public ListInventory(params InventoryItem[] items)
        {
            this.items = new List<InventoryItem>(items);
        }

        public void AddItem(InventoryItem item)
        {
            if (!this.items.Contains(item))
            {
                this.items.Add(item);
                this.OnItemAdded(item);
            }
        }
        
        public void RemoveItem(InventoryItem item)
        {
            if (this.items.Remove(item))
            {
                this.OnItemRemoved(item);
            }
        }

        public void RemoveItem(string name)
        {
            if (this.FindItem(name, out var item))
            {
                this.RemoveItem(item);
            }
        }

        public List<InventoryItem> GetItems()
        {
            return this.items.ToList();
        }

        public void AddListener(IInventoryListener listener)
        {
            this.observers.Add(listener);
        }

        public void RemoveObserver(IInventoryListener listener)
        {
            this.observers.Remove(listener);            
        }

        public bool FindItem(string name, out InventoryItem result)
        {
            foreach (var inventoryItem in this.items)
            {
                if (inventoryItem.Name == name)
                {
                    result = inventoryItem;
                    return true;
                }
            }
            
            result = null;
            return false;
        }

        private void OnItemAdded(InventoryItem item)
        {
            foreach (var observer in this.observers)
            {
                observer.OnItemAdded(item);
            }
        }
        
        private void OnItemRemoved(InventoryItem item)
        {
            foreach (var observer in this.observers)
            {
                observer.OnItemRemoved(item);
            }
        }
        
        public bool HasItem(InventoryItem equipmentItem)
        {
            return items.Contains(equipmentItem);
        }

        public bool FindItem(EquipmentType type, out InventoryItem result)
        {
            result = null;
        
            foreach (var item in items)
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
}