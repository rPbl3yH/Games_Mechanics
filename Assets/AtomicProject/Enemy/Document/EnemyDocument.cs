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
        public EnemyLifeSection EnemyLifeSection;

        [Section]
        public DeathSection DeathSection;

        [Section]
        public FollowSection FollowSection;

        [Section]
        public AttackSection AttackSection;
    }
}