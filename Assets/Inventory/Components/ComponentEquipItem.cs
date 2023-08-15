using Inventory.Equiper;
using UnityEngine;

namespace Inventory.Components
{
    class ComponentEquipItem : IComponent_EquipItem
    {
        public void Equip(EquipmentType type)
        {
            Debug.Log("Equip " + type);
        }
    }
}