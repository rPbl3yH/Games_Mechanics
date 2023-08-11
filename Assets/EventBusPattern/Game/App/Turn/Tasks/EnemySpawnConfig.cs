using System.Collections.Generic;
using UnityEngine;

namespace EventBusPattern
{
    [CreateAssetMenu(menuName = "Create EnemySpawnConfig", fileName = "EnemySpawnConfig", order = 0)]
    public class EnemySpawnConfig : ScriptableObject
    {
        public List<Vector2Int> SpawnPoints;
        public Enemy Prefab;
    }
}