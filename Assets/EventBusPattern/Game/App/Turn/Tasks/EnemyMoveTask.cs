using UnityEngine;
using Zenject;

namespace EventBusPattern
{
    public class EnemyMoveTask : Task
    {
        [Inject] private LevelMap _levelMap;
        
        protected override void OnRun()
        {
            var enemies = _levelMap.GetEntities<Enemy>();
            Debug.Log($"Enemy count: {enemies.Count}");
            Finish();
        }
    }
}