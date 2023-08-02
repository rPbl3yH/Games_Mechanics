using System;
using AtomicHomework.Atomic.Enemy.Document;
using AtomicHomework.Atomic.Enemy.Entity;
using AtomicProject.Entities.Components;
using UnityEngine;
using Zenject;

namespace AtomicHomework.Services
{
    public class EnemyFindService : MonoBehaviour
    {
        [Inject] private HeroService _heroService;
        [Inject] private EnemyService _enemyService;
        
        private Transform _heroTransform;
        private IFindComponent _findComponent;
        private EnemyEntity _closeEnemy;
        
        private void Start()
        {
            var hero = _heroService.GetHero();
            _heroTransform = hero.Get<TransformComponent>().Transform;
            _findComponent = hero.Get<FindComponent>();
        }

        private void Update()
        {
            var enemies = _enemyService.GetEnemies();
            if (enemies.Count == 0)
            {
                return;
            }
            
            var closeDistance = int.MaxValue;
            var closeEnemy = enemies[0];
            
            foreach (var enemy in enemies)
            {
                if (enemy == null)
                {
                    continue;
                }
                
                var enemyTransform = enemy.Get<TransformComponent>().Transform;
                var distance = Vector3.Distance(enemyTransform.position, _heroTransform.position);

                if (closeDistance > distance)
                {
                    closeEnemy = enemy;
                }
            }
            
            _findComponent.Find(closeEnemy);
        }
    }
}