using EventBusPattern.Game.App.Events;
using UnityEngine;
using Zenject;

namespace EventBusPattern.Game.GamePlay.Handlers.Logic
{
    public class DeathHandler : BaseHandler<DeathEvent>
    {
        [Inject] private LevelMap _levelMap;
        protected override void OnHandleEvent(DeathEvent evt)
        {
            if (evt.LifeEntity is ExplosionBarrel.ExplosionBarrel barrel)
            {
                EventBus.RaiseEvent(new ExplosionBarrelDeathEvent(barrel));
            }
            
            _levelMap.RemovePoint(LevelMapUtils.GetVector2Int(evt.LifeEntity.transform.position));
        }
    }
}