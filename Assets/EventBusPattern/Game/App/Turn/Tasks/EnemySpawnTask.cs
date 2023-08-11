using EventBusPattern.Game.App.Events;
using UnityEngine;
using Zenject;

namespace EventBusPattern
{
    public class EnemySpawnTask : Task
    {
        [Inject] private EventBus _eventBus;
        [Inject] private EnemySpawnConfig _config;

        protected override void OnRun()
        {
            var randomId = Random.Range(0, _config.SpawnPoints.Count);
            var randomPoint = _config.SpawnPoints[randomId];
            _eventBus.RaiseEvent(new SpawnEntityEvent(_config.Prefab, randomPoint));
            Finish();
        }
    }
}