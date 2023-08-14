using UnityEngine;

class ComponentTakeOffItem : IComponent_TakeOffItem
{
    public void TakeOff(EquipmentType type)
    {
        Debug.Log("Take off " + type);
    }
}