using Declarative;
using UnityEngine;

namespace AtomicProject.Hero
{
    public class HeroDocument : DeclarativeModel
    {
        public Transform Transform;
        
        [Section] 
        [SerializeField]
        public LifeSection _lifeSection;

        [Section] 
        [SerializeField]
        public MoveSection MoveSection;
        
        [Section] 
        [SerializeField]
        public RotateSection RotateSection;
        
        [Section]
        [SerializeField] 
        public FireSection FireSection;
    }
}
