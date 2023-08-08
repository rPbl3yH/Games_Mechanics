using System;
using EventBusPattern.Game.App.Events;
using Zenject;

namespace EventBusPattern.Game.GamePlay
{
    public class MoveHandler:  IInitializable, IDisposable
    {
        [Inject] private EventBus _eventBus;
    
        private void Move(MoveEvent moveEvent)
        {
            var transform = moveEvent.Character.transform;
            transform.LookAt(moveEvent.TargetPoint);
            transform.localPosition = moveEvent.TargetPoint;
        }

        public void Initialize()
        {
            _eventBus.Subscribe<MoveEvent>(Move);        
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe<MoveEvent>(Move);       
        }
    }
}