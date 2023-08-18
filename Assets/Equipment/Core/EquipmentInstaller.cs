using Entities;
using Lessons.MetaGame.Inventory;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Equipment.Core
{
    public class EquipmentInstaller : MonoBehaviour
    {
        [ShowInInspector]
        private ListEquipment _listEquipment;

        [Inject] private InventoryContext _inventoryContext;
        [Inject] private IEntity _entity;
        
        private void Start()
        {
            var equipmentService = new EquipmentService(_inventoryContext.GetInventory());
            _listEquipment = new ListEquipment(equipmentService);
            var effectApplier = new EquipmentEffectApplier(_entity, _listEquipment);
        }

        [Button]
        public void DebugEquip()
        {
            _inventoryContext.GetInventory().FindItem("boots", out var result);
            _listEquipment.Equip(result);
        } 
    }
}