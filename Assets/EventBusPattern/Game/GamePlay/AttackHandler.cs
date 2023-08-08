using System;
using EventBus.Game.App.Events;
using EventBus.Game.GamePlay.Area;
using Zenject;

public sealed class AttackHandler : IInitializable, IDisposable
{
    [Inject] private EventBusPattern.EventBus _eventBus;

    // public void Attack(Character source, Character target)
    // {
    //     target.TakeDamage(source.GetDamage());
    // }

    private void Attack(AttackEvent attackEvent)
    {
        attackEvent.Target.TakeDamage(attackEvent.Source.GetDamage());
    }

    public void Initialize()
    {
        _eventBus.Subscribe<AttackEvent>(Attack);
    }

    public void Dispose()
    {
        _eventBus.Unsubscribe<AttackEvent>(Attack);
    }
}