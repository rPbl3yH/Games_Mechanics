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
            Debug.Log("subscribe on " + nameof(DealDamageEffect));
            _eventBus.Subscribe<DealDamageEffect>(OnDealDamage);
        }

        private void OnDealDamage(DealDamageEffect effect)
        {
            Debug.Log("Deal damage effect!");
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe<DealDamageEffect>(OnDealDamage);
        }
    }
}