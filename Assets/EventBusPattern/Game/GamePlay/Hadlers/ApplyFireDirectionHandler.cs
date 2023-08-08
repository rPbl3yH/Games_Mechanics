using System;
using EventBus.Game.GamePlay.Area;
using EventBusPattern.Game.App.Events;
using Zenject;

namespace EventBusPattern.Game.GamePlay
{
    public sealed class ApplyFireDirectionHandler :  IInitializable, IDisposable
    {
        [Inject] private LevelMap _levelMap;

        private readonly Player _player;
        private readonly EventBus _eventBus;
    
        [Inject]
        public ApplyFireDirectionHandler(EventBus eventBus, Player player)
        {
            _player = player;
            _eventBus = eventBus;
        }
    
        public void Initialize()
        {
            _eventBus.Subscribe<ApplyFireDirectionEvent>(OnApplyDirection);
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe<ApplyFireDirectionEvent>(OnApplyDirection);
        }
    
        private void OnApplyDirection(ApplyFireDirectionEvent evt)
        {
            var nextPoint = evt.Character.transform.position + evt.Direction;
            var hasCharacter = false;

            for (int i = 0; i < LevelMap.Size; i++)
            {
                if (_levelMap.HasCharacter(nextPoint))
                {
                    hasCharacter = true;
                    break;
                }

                nextPoint += evt.Direction;
            }

            if (!hasCharacter)
            {
                return;
            }
            
            var target = _levelMap.GetCharacter(nextPoint);
            _eventBus.RaiseEvent(new DealDamageEvent(_player, target));
        }
    }
}