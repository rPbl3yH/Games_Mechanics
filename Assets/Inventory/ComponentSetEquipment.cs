using UnityEngine;

class ComponentSetEquipment : IComponent_SetEquipment
{
    public void Equip(EquipmentType type)
    {
        Debug.Log("Equip " + type);
    }
}