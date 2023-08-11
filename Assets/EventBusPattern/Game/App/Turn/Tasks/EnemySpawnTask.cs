using UnityEngine;
using Zenject;

namespace EventBusPattern
{
    public class EnemySpawnTask : Task
    {
        [Inject] private LevelMap _levelMap;
        [Inject] private EnemySpawnConfig _config;

        protected override void OnRun()
        {
            Debug.Log("Spawn!");
            Finish();
        }
    }
}