using System;
using AtomicProject.Atomic.Values;
using Elementary;
using Entities;
using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Game
{
    public class PlayerEntity : MonoEntityBase
    {
        [SerializeField] private PlayerModel _playerModel;
        [SerializeField] private MonoEffector<IEffect> _monoEffector;
        private void Awake()
        {
            Add(new ComponentEquipItem());
            Add(new ComponentTakeOffItem());
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