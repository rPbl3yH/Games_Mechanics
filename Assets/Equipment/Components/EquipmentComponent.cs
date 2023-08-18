using System;
using Inventory.Equiper;
using UnityEngine;

namespace Inventory.Components
{
    [Serializable]
    public class EquipmentComponent : IComponent_Equipment
    {
        [field: SerializeField] public EquipmentType Type { get; set; }
    }
}