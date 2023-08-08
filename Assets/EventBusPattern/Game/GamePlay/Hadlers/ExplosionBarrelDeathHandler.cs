using System;
using EventBus.Game.GamePlay.Area;
using EventBusPattern.Game.App.Events;
using Zenject;

namespace EventBusPattern.Game.GamePlay
{
    public class ExplosionBarrelDeathHandler : IInitializable, IDisposable
    {
        [Inject] private EventBus _eventBus;
        [Inject] private LevelMap _levelMap;

        public void Initialize()
        {
            _eventBus.Subscribe<ExplosionBarrelDeathEvent>(OnDeath);
        }

        private void OnDeath(ExplosionBarrelDeathEvent evt)
        {
            var barrel = evt.Barrel;
            var neighbourEntities = _levelMap.GetNeighbourEntities(barrel.transform.position);
            foreach (var entity in neighbourEntities)
            {
                foreach (var effect in barrel.EffectsOnDeath)
                {
                    effect.Source = barrel;
                    effect.Target = entity;
                    _eventBus.RaiseEvent(effect);
                }    
            }
            
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe<ExplosionBarrelDeathEvent>(OnDeath);
        }
    }
}