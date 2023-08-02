using System;
using AtomicHomework.Atomic.Enemy.Entity;
using Declarative;

namespace AtomicHomework.Hero
{
    [Serializable]
    public class HeroCore
    {
        [Section] 
        public LifeSection LifeSection;

        [Section] 
        public MoveSection MoveSection;
        
        [Section] 
        public RotateSection RotateSection;
        
        [Section]
        public FireSection FireSection;

        [Section]
        public HeroStates States;

        [Section] 
        public FindEnemySection FindEnemySection;
    }
}