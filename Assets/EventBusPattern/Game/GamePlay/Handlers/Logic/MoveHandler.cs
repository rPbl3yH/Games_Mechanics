using System;
using EventBusPattern.Game.App.Events;
using Zenject;

namespace EventBusPattern.Game.GamePlay
{
    public class MoveHandler :  BaseHandler<MoveEvent>
    {
        protected override void OnHandleEvent(MoveEvent evt)
        {
            var transform = evt.LifeEntity.transform;
            transform.LookAt(evt.TargetPoint);
        }
    }
}