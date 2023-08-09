using System;
using AtomicProject.Hero;
using Declarative;
using UnityEngine;

namespace StateMachine.States
{
    [Serializable]
    public class ShootState : CompositeState
    {
        [HideInInspector]
        public RotateState RotateState;

        public FireState FireState;

        [Construct]
        public void ConstructSelf()
        {
            SetStates(RotateState, FireState);
        }
        
        [Construct]
        public void ConstructStates(HeroDocument heroDocument)
        {
            RotateState.Construct(heroDocument.Transform, heroDocument.Core._findEnemySection.ClosetEnemyPoint);
            FireState.Construct(heroDocument.Core.FireSection.OnFire);
        }
    }
}