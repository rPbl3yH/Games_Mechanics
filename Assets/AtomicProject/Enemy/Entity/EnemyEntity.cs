using AtomicProject.Enemy.Document;
using AtomicProject.Entities.Components;
using AtomicProject.Entities.Components.Damage;
using AtomicProject.Entities.Components.Follow;
using Entities;
using UnityEngine;

namespace AtomicProject.Enemy.Entity
{
    public class EnemyEntity : MonoEntityBase
    {
        [SerializeField] private EnemyDocument _enemyDocument;
        
        private void Awake()
        {
            Add(new TakeBulletDamageComponent(_enemyDocument.LifeSection.OnTakeDamage));
            Add(new FollowComponent(_enemyDocument._followSection.FollowRequest));
            Add(new TransformComponent(_enemyDocument.transform));
        }
    }
}