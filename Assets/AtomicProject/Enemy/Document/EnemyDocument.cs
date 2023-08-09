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
        public DeathSection _deathSection;

        [Section]
        public FollowSection _followSection;

        [Section]
        public AttackSection AttackSection;
    }
}