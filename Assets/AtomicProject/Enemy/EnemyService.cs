using System.Collections.Generic;
using AtomicProject.Enemy.Entity;
using Entities;
using Zenject;

namespace AtomicProject.Enemy
{
    public class EnemyService
    {
        private EnemySpawner _enemySpawner;

        private List<MonoEntity> _enemies = new();
        
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

        public List<MonoEntity> GetEnemies()
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