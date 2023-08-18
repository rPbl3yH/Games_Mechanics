using AtomicProject.Atomic.Values;
using Elementary;
using Entities;
using Game.GameEngine.Mechanics;
using Inventory.Player;
using Zenject;

namespace Inventory.EffectHandlers
{
    public sealed class DamageEffectHandler : IEffectHandler<IEffect>
    {
        private AtomicVariable<float> _damage;

        public DamageEffectHandler(AtomicVariable<float> damage)
        {
            _damage = damage;
        }

        public void OnApply(IEffect effect)
        {
            if (effect.TryGetParameter<float>(EffectId.DAMAGE, out var value))
            {
                _damage.Value += value;
            }
        }
        
        public void OnDiscard(IEffect effect)
        {
            if (effect.TryGetParameter<float>(EffectId.DAMAGE, out var multiplier))
            {
                _damage.Value -= multiplier;
            }
        }
    }
}