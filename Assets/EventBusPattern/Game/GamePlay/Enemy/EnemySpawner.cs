using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace EventBusPattern
{
    public class EnemySpawner : MonoBehaviour, IInitializable
    {
        [SerializeField] private List<Vector2Int> _spawnPoints;
        [SerializeField] private Enemy _prefab;
        [Inject] private LevelMap _levelMap;
        
        public void Initialize()
        {
            foreach (var point in _spawnPoints)
            {
                var spawnPoint = new Vector3(point.x, 0f, point.y);
                var enemy = Instantiate(_prefab, spawnPoint, Quaternion.identity);
                _levelMap.AddEntity(point, enemy);
            }
        }
    }
}