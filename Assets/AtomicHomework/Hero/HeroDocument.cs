using Declarative;
using UnityEngine;

namespace AtomicHomework.Hero
{
    public class HeroDocument : DeclarativeModel
    {
        public Transform Transform;
        
        [Section] 
        [SerializeField]
        public LifeSection _lifeSection;

        [Section] 
        [SerializeField]
        public MoveSection _moveSection;
        
        [Section] 
        [SerializeField]
        public RotateSection _rotateSection;
        
        [Section]
        [SerializeField] 
        public FireSection _fireSection;
    }
}
