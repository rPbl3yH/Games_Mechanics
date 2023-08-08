using System;
using EventBus.Game.GamePlay.Area;
using EventBusPattern.Game.App.Events;
using Zenject;

namespace EventBusPattern.Game.GamePlay
{
    public sealed class ApplyMoveDirectionHandler :  IInitializable, IDisposable
    {
        [Inject] 
        private LevelMap _levelMap;

        private readonly Player _player;
        private readonly EventBus _eventBus;
    
        [Inject]
        public ApplyMoveDirectionHandler(EventBus eventBus, Player player)
        {
            _player = player;
            _eventBus = eventBus;
        }
    
        public void Initialize()
        {
            _eventBus.Subscribe<ApplyMoveDirectionEvent>(OnApplyDirection);
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe<ApplyMoveDirectionEvent>(OnApplyDirection);
        }
    
        private void OnApplyDirection(ApplyMoveDirectionEvent evt)
        {
            var nextPoint = evt.LifeEntity.transform.localPosition + evt.Direction;
            
            if (_levelMap.IsWalkable(nextPoint))
            {
                _eventBus.RaiseEvent(new MoveEvent(_player, nextPoint));
            }
        }
    }
}