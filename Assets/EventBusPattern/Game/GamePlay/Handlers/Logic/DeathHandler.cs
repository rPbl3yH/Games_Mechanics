using EventBusPattern.Game.App.Events;
using UnityEngine;

namespace EventBusPattern.Game.GamePlay.Handlers.Logic
{
    public class DeathHandler : BaseHandler<DeathEvent>
    {
        protected override void OnHandleEvent(DeathEvent evt)
        {
            if (evt.LifeEntity is ExplosionBarrel.ExplosionBarrel barrel)
            {
                EventBus.RaiseEvent(new ExplosionBarrelDeathEvent(barrel));
            }
            //Object.Destroy(evt.LifeEntity.gameObject);
        }
    }
}