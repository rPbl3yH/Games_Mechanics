using AtomicProject.Atomic.Values;
using Elementary;
using Entities;
using Game.GameEngine.Mechanics;
using Inventory.Components;
using UnityEngine;

namespace Inventory.Player
{
    public class PlayerEntity : MonoEntityBase
    {
        [SerializeField] private PlayerModel _playerModel;
        [SerializeField] private MonoEffector<IEffect> _monoEffector;
        private void Awake()
        {
            Add(new ComponentEquipItem(_playerModel.Equipments));
            Add(new ComponentTakeOffItem(_playerModel.Equipments));
            Add(new Component_Effector(_monoEffector));
            Add(new ComponentGetDamage(_playerModel.Damage));
        }
    }

    public class ComponentGetDamage : IComponent_GetDamage
    {
        private readonly AtomicVariable<float> _damage;

        public ComponentGetDamage(AtomicVariable<float> damage)
        {
            _damage = damage;
        }

        public AtomicVariable<float> GetDamage()
        {
            return _damage;
        }
    }

    public interface IComponent_GetDamage
    {
        AtomicVariable<float> GetDamage();
    }
}