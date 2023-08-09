using EventBusPattern.Game.App.Events;

namespace EventBusPattern
{
    public sealed class DealDamageHandler : BaseHandler<DealDamageEvent>
    {
        protected override void OnHandleEvent(DealDamageEvent evt)
        {
            evt.Target.TakeDamage(evt.Source.GetDamage());
        }
    }
}