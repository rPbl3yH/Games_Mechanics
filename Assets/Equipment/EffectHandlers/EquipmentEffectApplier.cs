using Entities;
using Game.GameEngine.Mechanics;
using Lessons.MetaGame.Inventory;

public class EquipmentEffectApplier
{
    private ListEquipment _listEquipment;
    private IEntity _character;
    
    public EquipmentEffectApplier(IEntity character, ListEquipment listEquipment)
    {
        _listEquipment = listEquipment;
        _listEquipment.OnEquipped += OnEquipped;
        _character = character;
    }

    private void OnEquipped(InventoryItem item)
    {
        if (IsEffectible(item))
        {
            var effect = GetEffect(item);
            _character.Get<IComponent_Effector>().Apply(effect);
        }
    }

    private static IEffect GetEffect(InventoryItem item)
    {
        return item.GetComponent<IComponent_GetEffect>().Effect;
    }
    
    private static bool IsEffectible(InventoryItem item)
    {
        return item.Flags.HasFlag(InventoryItemFlags.EFFECTIBLE);
    }
}