using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

namespace EventBus.Game.GamePlay.Area
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
                _levelMap.AddCharacter(point, enemy);
            }
        }
    }
}