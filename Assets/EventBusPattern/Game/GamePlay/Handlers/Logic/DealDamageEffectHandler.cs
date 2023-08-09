using System;
using EventBusPattern.Game.App.Events;
using Zenject;

namespace EventBusPattern
{
    public class DealDamageEffectHandler : BaseHandler<DealDamageEffect>
    {
        protected override void OnHandleEvent(DealDamageEffect effect)
        {
            EventBus.RaiseEvent(new DealDamageEvent(effect.Source, effect.Target));
        }
    }
}