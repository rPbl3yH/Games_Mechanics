using System;
using EventBusPattern.Game.App.Events;
using UnityEngine;
using Zenject;

namespace EventBusPattern.Game.GamePlay
{
    public class DealDamageEffectHandler : IDisposable, IInitializable
    {
        [Inject] private EventBus _eventBus;
        
        public void Initialize()
        {
            _eventBus.Subscribe<DealDamageEffect>(OnDealDamage);
        }

        private void OnDealDamage(DealDamageEffect effect)
        {
            _eventBus.RaiseEvent(new DealDamageEvent(effect.Source, effect.Target));
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe<DealDamageEffect>(OnDealDamage);
        }
    }
}