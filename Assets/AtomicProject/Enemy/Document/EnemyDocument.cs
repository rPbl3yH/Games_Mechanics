using AtomicHomework.Atomic.Enemy.Document;
using AtomicHomework.Hero;
using Declarative;
using UnityEngine;

namespace AtomicHomework.Enemy.Document
{
    public class EnemyDocument : DeclarativeModel
    {
        public Transform Transform;
        
        [Section] 
        public LifeSection LifeSection;

        [Section]
        public EnemyDeathSection _enemyDeathSection;

        [Section]
        public FollowSection FollowSection;

        [Section]
        public AttackSection AttackSection;
    }
}