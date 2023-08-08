using System;
using EventBusPattern.Game.App.Effects;
using EventBusPattern.Game.App.Events;
using Zenject;

namespace EventBusPattern
{
    public class ForceDirectionEffectHandler : IInitializable, IDisposable
    {
        [Inject] private EventBus _eventBus;
        
        public void Initialize()
        {
            _eventBus.Subscribe<ForceDirectionEffect>(OnForceDirectionEffect);
        }

        private void OnForceDirectionEffect(ForceDirectionEffect effect)
        {
            var direction = (effect.Target.transform.position - effect.Source.transform.position).normalized;
            _eventBus.RaiseEvent(new ApplyMoveDirectionEvent(effect.Target, direction));
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe<ForceDirectionEffect>(OnForceDirectionEffect);
        }
    }
}