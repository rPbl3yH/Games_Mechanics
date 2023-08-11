using System.Collections.Generic;
using EventBusPattern.Game.App.Events;
using UnityEngine;
using Zenject;

namespace EventBusPattern
{
    public class SpawnEntityEventHandler : BaseHandler<SpawnEntityEvent>
    {
        [Inject] private LevelMap _levelMap;
        
        protected override void OnHandleEvent(SpawnEntityEvent evt)
        {
            var spawnPosition = new Vector3(evt.SpawnPoint.x, 0f, evt.SpawnPoint.y);
            var entity = Object.Instantiate(evt.LifeEntity, spawnPosition, Quaternion.identity);
            _levelMap.AddEntity(evt.SpawnPoint, entity);
        }
    }
}