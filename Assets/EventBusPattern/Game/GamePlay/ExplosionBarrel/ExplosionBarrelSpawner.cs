using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace EventBusPattern.Game.GamePlay.ExplosionBarrel
{
    public class ExplosionBarrelSpawner : MonoBehaviour
    {
        [SerializeField] private List<Vector3> _spawnPoints;
        [SerializeField] private ExplosionBarrel _prefab;
        [Inject] private LevelMap _levelMap;
        [Inject] private EventBus _eventBus;
        
        private void Start()
        {
            foreach (var spawnPoint in _spawnPoints)
            {
                var barrel = Instantiate(_prefab, spawnPoint, Quaternion.identity);
                barrel.Construct(_eventBus);
                _levelMap.AddEntity(spawnPoint, barrel);
            }
        }
    }
}