using Declarative;
using UnityEngine;

namespace AtomicHomework.Hero
{
    public class HeroDocument : DeclarativeModel
    {
        public Transform Transform;
        
        [Section] 
        [SerializeField]
        public HeroLifeSection HeroLifeSection;

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
