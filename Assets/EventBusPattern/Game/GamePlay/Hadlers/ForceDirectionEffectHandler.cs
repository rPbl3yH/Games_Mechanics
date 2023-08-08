using System;
using EventBusPattern.Game.App.Effects;
using EventBusPattern.Game.App.Events;
using UnityEngine;
using Zenject;

namespace EventBusPattern
{
    public class ForceDirectionEffectHandler : IInitializable, IDisposable
    {
        [Inject] private EventBus _eventBus;
        [Inject] private LevelMap _levelMap;
        
        public void Initialize()
        {
            _eventBus.Subscribe<ForceDirectionEffect>(OnForceDirectionEffect);
        }

        private void OnForceDirectionEffect(ForceDirectionEffect effect)
        {
            var direction = (effect.Target.transform.position - effect.Source.transform.position).normalized;
            Debug.Log("Direction " + direction);
            var nextPoint = effect.Target.transform.position + direction;
            
            if (_levelMap.IsWalkable(nextPoint))
            {
                _eventBus.RaiseEvent(new MoveEvent(effect.Target, nextPoint));
            }
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe<ForceDirectionEffect>(OnForceDirectionEffect);
        }
    }
}