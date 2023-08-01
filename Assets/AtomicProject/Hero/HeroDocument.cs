using System;
using Declarative;
using UnityEngine;

namespace AtomicHomework.Hero
{
    public class HeroDocument : DeclarativeModel
    {
        public Transform Transform;

        public HeroCore Core;

        public HeroVisual Visual;
    }

    [Serializable]
    public class HeroCore
    {
        [Section] 
        [SerializeField]
        public LifeSection LifeSection;

        [Section] 
        [SerializeField]
        public MoveSection MoveSection;
        
        [Section] 
        [SerializeField]
        public RotateSection RotateSection;
        
        [Section]
        [SerializeField] 
        public FireSection FireSection;

        [Section]
        [SerializeField]
        public HeroStates States;
    }

    [Serializable]
    public class HeroStates
    {
        public StateMachine.StateMachine StateMachine;

        [Construct]
        public void Construct()
        {
            
        }
    }

    [Serializable]
    public class HeroVisual
    {
        
    }
}
