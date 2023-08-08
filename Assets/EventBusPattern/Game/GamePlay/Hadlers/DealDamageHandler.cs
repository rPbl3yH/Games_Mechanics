using System;
using EventBusPattern.Game.App.Events;
using Zenject;

namespace EventBusPattern.Game.GamePlay
{
    public sealed class DealDamageHandler : IInitializable, IDisposable
    {
        [Inject] private EventBus _eventBus;
        
        private void Attack(DealDamageEvent dealDamageEvent)
        {
            dealDamageEvent.Target.TakeDamage(dealDamageEvent.Source.GetDamage());
        }

        public void Initialize()
        {
            _eventBus.Subscribe<DealDamageEvent>(Attack);
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe<DealDamageEvent>(Attack);
        }
    }
}