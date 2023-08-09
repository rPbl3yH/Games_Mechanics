using AtomicProject.Hero;
using Declarative;
using UnityEngine;

namespace AtomicProject.Enemy.Document
{
    public class EnemyDocument : DeclarativeModel
    {
        public Transform Transform;
        
        [Section] 
        public LifeSection LifeSection;

        [Section]
        public DeathSection DeathSection;

        [Section]
        public FollowSection FollowSection;

        [Section]
        public AttackSection AttackSection;
    }
}