using System;
using AtomicProject.Hero;
using Declarative;
using UnityEngine;

namespace StateMachine.States
{
    [Serializable]
    public class ShootState : CompositeState
    {
        public AnimationState AnimationState;
        [HideInInspector]
        public RotateState RotateState;

        public FireState FireState;

        [Construct]
        public void ConstructSelf()
        {
            SetStates(AnimationState, RotateState, FireState);
        }
        
        [Construct]
        public void ConstructStates(HeroDocument heroDocument)
        {
            AnimationState.Construct(heroDocument.Visual.Animator);
            RotateState.Construct(heroDocument.Transform, heroDocument.Core.FindEnemySection.ClosetEnemyPoint);
            FireState.Construct(heroDocument.Core.FireSection.OnFire);
        }
    }
}