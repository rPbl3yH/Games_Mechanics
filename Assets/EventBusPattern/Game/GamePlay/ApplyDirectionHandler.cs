using System;
using EventBus.Game.GamePlay.Area;
using EventBusPattern.Game.App.Events;
using Zenject;

namespace EventBusPattern.Game.GamePlay
{
    public sealed class ApplyDirectionHandler :  IInitializable, IDisposable
    {
        [Inject] 
        private LevelMap _levelMap;

        private readonly Player _player;
        private readonly EventBus _eventBus;
    
        [Inject]
        public ApplyDirectionHandler(EventBus eventBus, Player player)
        {
            _player = player;
            _eventBus = eventBus;
        }
    
        public void Initialize()
        {
            _eventBus.Subscribe<ApplyDirectionEvent>(OnApplyDirection);
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe<ApplyDirectionEvent>(OnApplyDirection);
        }
    
        private void OnApplyDirection(ApplyDirectionEvent evt)
        {
            var nextPoint = evt.Character.transform.localPosition + evt.Direction;
            
            if (_levelMap.IsWalkable(nextPoint))
            {
                _eventBus.RaiseEvent(new MoveEvent(_player, nextPoint));
            }
            else
            {
                if (_levelMap.HasCharacter(nextPoint))
                {
                    var target = _levelMap.GetCharacter(nextPoint);
                    _eventBus.RaiseEvent(new AttackEvent(_player, target));
                }
            }
        }
    }
}