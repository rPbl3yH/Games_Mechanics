using EventBusPattern.Game.App.Effects;
using EventBusPattern.Game.App.Events;

namespace EventBusPattern
{
    public class ForceDirectionEffectHandler : BaseHandler<ForceDirectionEffect>
    {
        protected override void OnHandleEvent(ForceDirectionEffect effect)
        {
            var direction = (effect.Target.transform.position - effect.Source.transform.position).normalized;
            EventBus.RaiseEvent(new ApplyMoveDirectionEvent(effect.Target, direction));
        }
    }
}