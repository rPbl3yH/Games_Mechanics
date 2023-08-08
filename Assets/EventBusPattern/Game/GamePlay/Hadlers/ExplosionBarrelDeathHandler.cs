using System;
using EventBus.Game.GamePlay.Area;
using EventBusPattern.Game.App.Events;
using UnityEngine;
using Zenject;

namespace EventBusPattern.Game.GamePlay
{
    public class ExplosionBarrelDeathHandler : IInitializable, IDisposable
    {
        [Inject] private EventBus _eventBus;

        public void Initialize()
        {
            _eventBus.Subscribe<ExplosionBarrelDeathEvent>(OnDeath);
        }

        private void OnDeath(ExplosionBarrelDeathEvent evt)
        {
            var barrel = evt.Barrel;
            foreach (var effect in barrel.EffectsOnDeath)
            {
                _eventBus.RaiseEvent(effect);
            }
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe<ExplosionBarrelDeathEvent>(OnDeath);
        }
    }
}