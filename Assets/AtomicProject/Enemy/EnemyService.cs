using System.Collections.Generic;
using AtomicHomework.Atomic.Enemy.Entity;
using Entities;
using Zenject;

namespace AtomicHomework.Atomic.Enemy.Document
{
    public class EnemyService
    {
        private EnemySpawner _enemySpawner;

        private List<IEntity> _enemies = new();
        
        [Inject] 
        public EnemyService(EnemySpawner enemySpawner)
        {
            _enemySpawner = enemySpawner;
            _enemySpawner.OnSpawn += OnSpawn;
        }

        private void OnSpawn(EnemyEntity enemy)
        {
            _enemies.Add(enemy);
        }

        public List<IEntity> GetEnemies()
        {
            for (int i = _enemies.Count - 1; i >= 0; i--)
            {
                if (_enemies[i] == null)
                {
                    _enemies.RemoveAt(i);
                }
            }
            return _enemies;
        }
    }
}