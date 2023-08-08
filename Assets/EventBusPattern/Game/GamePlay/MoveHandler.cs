using System;
using EventBus.Game.App.Events;
using Zenject;

public class MoveHandler:  IInitializable, IDisposable
{
    [Inject] private EventBusPattern.EventBus _eventBus;
    
    // public void Move(Character character, Vector3 nextPoint)
    // {
    //     character.transform.LookAt(nextPoint);
    //     character.transform.localPosition = nextPoint;
    // }
    //
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