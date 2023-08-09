using System;
using EventBusPattern.Game.App.Events;
using Zenject;

namespace EventBusPattern
{
    public sealed class ApplyMoveDirectionHandler :  BaseHandler<ApplyMoveDirectionEvent>
    {
        [Inject] private LevelMap _levelMap;
        
        protected override void OnHandleEvent(ApplyMoveDirectionEvent evt)
        {
            var nextPoint = evt.LifeEntity.transform.position + evt.Direction;
            
            if (_levelMap.IsWalkable(nextPoint))
            {
                var nextPointInt = LevelMapUtils.GetVector2Int(nextPoint);
                _levelMap.RemovePoint(LevelMapUtils.GetVector2Int(evt.LifeEntity.transform.position));
                _levelMap.AddEntity(nextPointInt, evt.LifeEntity);
                
                EventBus.RaiseEvent(new MoveEvent(evt.LifeEntity, nextPoint, 0.3f));
            }
        }
    }
}