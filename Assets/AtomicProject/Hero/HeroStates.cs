using System;
using Declarative;
using StateMachine;
using UnityEngine;

namespace AtomicHomework.Hero
{
    [Serializable]
    public class HeroStates
    {
        public StateMachine.StateMachine StateMachine;

        [Section]
        [HideInInspector]
        public IdleState IdleState;
        
        [Section]
        [HideInInspector]
        public RunState RunState;

        [Construct]
        public void Construct(MoveSection moveSection)
        {
            StateMachine.Construct(
                (HeroStateType.Idle, IdleState),
                (HeroStateType.Run, RunState)
                );

            moveSection.OnMoveStarted += () => StateMachine.SwitchState(HeroStateType.Run);
            moveSection.OnMoveFinished += () => StateMachine.SwitchState(HeroStateType.Idle);
        }
    }
}