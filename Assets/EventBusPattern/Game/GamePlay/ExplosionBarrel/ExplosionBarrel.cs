using EventBusPattern.Game.App.Events;
using UnityEngine;
using Zenject;

namespace EventBusPattern.Game.GamePlay.ExplosionBarrel
{
    public class ExplosionBarrel : LifeEntity
    {
        [SerializeReference] public IEffect[] EffectsOnDeath;

        private EventBus _eventBus;

        public void Construct(EventBus eventBus)
        {
            _eventBus = eventBus;
        }
        
        public override void Death()
        {
            base.Death();
            _eventBus.RaiseEvent(new ExplosionBarrelDeathEvent(this));
        }
    }

    public class DealDamageEffect : IEffect
    {
        public void ApplyEffect()
        {
            
        }
    }

    public interface IEffect
    {
        void ApplyEffect();
    }
}