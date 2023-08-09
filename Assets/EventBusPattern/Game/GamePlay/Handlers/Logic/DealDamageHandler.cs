using EventBusPattern.Game.App.Events;

namespace EventBusPattern
{
    public sealed class DealDamageHandler : BaseHandler<DealDamageEvent>
    {
        protected override void OnHandleEvent(DealDamageEvent evt)
        {
            evt.Target.Life -= evt.Source.Damage;
            
            if (evt.Target.Life <= 0)
            {
                EventBus.RaiseEvent(new DeathEvent(evt.Target));    
            }
        }
    }
}