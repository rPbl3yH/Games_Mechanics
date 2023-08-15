using Inventory.Equiper;
using UnityEngine;

namespace Inventory.Components
{
    class ComponentTakeOffItem : IComponent_TakeOffItem
    {
        public void TakeOff(EquipmentType type)
        {
            Debug.Log("Take off " + type);
        }
    }
}