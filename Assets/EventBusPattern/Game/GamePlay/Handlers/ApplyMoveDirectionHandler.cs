using System;
using EventBusPattern.Game.App.Events;
using Zenject;

namespace EventBusPattern
{
    public sealed class ApplyMoveDirectionHandler :  IInitializable, IDisposable
    {
        [Inject] private LevelMap _levelMap;
        [Inject] private readonly EventBus _eventBus;
        
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
            var nextPoint = evt.LifeEntity.transform.position + evt.Direction;
            
            if (_levelMap.IsWalkable(nextPoint))
            {
                var nextPointInt = LevelMapUtils.GetVector2Int(nextPoint);
                _levelMap.RemovePoint(LevelMapUtils.GetVector2Int(evt.LifeEntity.transform.position));
                _levelMap.AddEntity(nextPointInt, evt.LifeEntity);
                
                _eventBus.RaiseEvent(new MoveEvent(evt.LifeEntity, nextPoint));
            }
        }
    }
}