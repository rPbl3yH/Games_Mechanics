using Elementary;
using Entities;
using Game.GameEngine.Mechanics;
using Inventory.EffectHandlers;
using UnityEngine;

namespace Inventory.Player
{
    public class PlayerEntity : MonoEntityBase
    {
        [SerializeField] private PlayerModel _playerModel;
        
        private void Awake()
        {
            Add(new ComponentGetDamage(_playerModel.Damage));
            
            var effector = new Effector<IEffect>();
            effector.AddHandler(new DamageEffectHandler(_playerModel.Damage));
            Add(new Component_Effector(effector));
        }
    }
}