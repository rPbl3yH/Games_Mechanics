using System;
using Declarative;
using StateMachine;

namespace AtomicHomework.Hero
{
    [Serializable]
    public class HeroStates
    {
        public StateMachine.StateMachine StateMachine;

        [Section]
        public IdleState IdleState;
        
        [Section]
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