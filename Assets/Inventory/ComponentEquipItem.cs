using UnityEngine;

class ComponentEquipItem : IComponent_EquipItem
{
    public void Equip(EquipmentType type)
    {
        Debug.Log("Equip " + type);
    }
}