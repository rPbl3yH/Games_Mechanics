using System.Collections;
using AtomicProject.Enemy.Entity;
using AtomicProject.Entities.Components.Follow;
using AtomicProject.Hero;
using UnityEngine;

namespace AtomicProject.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyEntity _enemy;
        [SerializeField] private float _spawnTime = 2f;
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private HeroDocument _heroDocument;

        public void Start()
        {
            StartCoroutine(StartSpawn());
        }

        private IEnumerator StartSpawn()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnTime);
                var spawnPoint = GetRandomPoint();
                var enemy = Instantiate(_enemy, spawnPoint.position, spawnPoint.rotation);
                
                if (enemy.TryGet(out IFollowComponent followComponent))
                {
                    followComponent.Follow(_heroDocument.Transform);
                }   
            }
        }

        private Transform GetRandomPoint()
        {
            return _spawnPoints[Random.Range(0, _spawnPoints.Length)];
        }
    }
}