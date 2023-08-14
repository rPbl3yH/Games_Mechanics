using Entities;
using Game;
using Game.Gameplay.Hero;
using GameSystem;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Lessons.MetaGame.Inventory
{
    public sealed class InventoryContext : MonoBehaviour, IInitializable
    {
        [ShowInInspector]
        private readonly ListInventory inventory = new();

        [Inject] private IEntity _entity;
        
        [Button]
        public void AddItem(InventoryItemConfig config)
        {
            var prefab = config.item;
            var inventoryItem = prefab.Clone();
            this.inventory.AddItem(inventoryItem);
        }

        [Button]
        public void RemoveItem(InventoryItemConfig config)
        {
            this.inventory.RemoveItem(config.item.Name);
        }

        public void Initialize()
        {
            inventory.AddObserver(new InventoryItemEquiper(_entity));
        }
    }
}