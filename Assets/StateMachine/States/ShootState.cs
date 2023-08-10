using System;
using AtomicProject.Atomic.Values;
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
            RotateState.Construct(heroDocument.Transform,
                new AtomicValue<Quaternion>(() =>
                    Quaternion.LookRotation(heroDocument.Core.FindEnemySection.ClosetEnemyPoint.Value - heroDocument.Transform.position)));
            FireState.Construct(heroDocument.Core.FireSection.FireRequest);
        }
    }
}