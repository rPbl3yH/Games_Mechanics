using AtomicHomework.Entities.Components;
using AtomicProject.Enemy.Document;
using Entities;
using UnityEngine;

namespace AtomicHomework.Atomic.Enemy.Entity
{
    public class EnemyEntity : MonoEntityBase
    {
        [SerializeField] private EnemyDocument _enemyDocument;
        
        private void Awake()
        {
            Add(new TakeBulletDamageComponent(_enemyDocument.LifeSection.OnTakeDamage));
            Add(new FollowComponent(_enemyDocument.FollowSection.OnFollow));
        }
    }
}