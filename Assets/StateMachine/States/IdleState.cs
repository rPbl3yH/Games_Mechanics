using System;
using AtomicProject.Hero;
using Declarative;
using UnityEngine;

namespace StateMachine.States
{
    [Serializable]
    public class IdleState : CompositeState
    {
        [HideInInspector]
        public RotateState RotateState;

        [Construct]
        public void ConstructSelf()
        {
            SetStates(RotateState);            
        }

        [Construct]
        public void ConstructStates(HeroDocument heroDocument)
        {
            RotateState.Construct(heroDocument.Transform, heroDocument.Core.RotateSection.TargetPoint);
        }
    }
}