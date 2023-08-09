using System;
using EventBusPattern.Game.App.Events;
using Zenject;

namespace EventBusPattern
{
    public class ExplosionBarrelDeathHandler : BaseHandler<ExplosionBarrelDeathEvent>
    {
        [Inject] private LevelMap _levelMap;

        protected override void OnHandleEvent(ExplosionBarrelDeathEvent evt)
        {
            var barrel = evt.Barrel;
            var neighbourEntities = _levelMap.GetNeighbourEntities(barrel.transform.position);
            
            foreach (var entity in neighbourEntities)
            {
                foreach (var effect in barrel.EffectsOnDeath)
                {
                    effect.Source = barrel;
                    effect.Target = entity;
                    EventBus.RaiseEvent(effect);
                }    
            }
        }
    }
}