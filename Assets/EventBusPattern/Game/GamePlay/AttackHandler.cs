using System;
using EventBusPattern.Game.App.Events;
using Zenject;

namespace EventBusPattern.Game.GamePlay
{
    public sealed class AttackHandler : IInitializable, IDisposable
    {
        [Inject] private EventBus _eventBus;
        
        private void Attack(AttackEvent attackEvent)
        {
            attackEvent.Target.TakeDamage(attackEvent.Source.GetDamage());
        }

        public void Initialize()
        {
            _eventBus.Subscribe<AttackEvent>(Attack);
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe<AttackEvent>(Attack);
        }
    }
}