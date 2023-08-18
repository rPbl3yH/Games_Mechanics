using AtomicProject.Atomic.Values;
using Elementary;
using Entities;
using Game.GameEngine.Mechanics;
using Inventory.Player;
using Zenject;

namespace Inventory.EffectHandlers
{
    public sealed class DamageEffectHandler : MonoEffectHandler<IEffect>
    {
        private AtomicVariable<float> _damage;
        [Inject] private IEntity _entity;

        private void Start()
        {
            _damage = _entity.Get<ComponentGetDamage>().GetDamage();
        }

        public override void OnApply(IEffect effect)
        {
            if (effect.TryGetParameter<float>(EffectId.DAMAGE, out var value))
            {
                _damage.Value += value;
            }
        }
        
        public override void OnDiscard(IEffect effect)
        {
            if (effect.TryGetParameter<float>(EffectId.DAMAGE, out var multiplier))
            {
                _damage.Value -= multiplier;
            }
        }
    }
}