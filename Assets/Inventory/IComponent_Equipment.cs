using System;
using UnityEngine;

public interface IComponent_Equipment
{
    EquipmentType Type { get; set; }
}

[Serializable]
class EquipmentComponent : IComponent_Equipment
{
    [field: SerializeField] public EquipmentType Type { get; set; }
}