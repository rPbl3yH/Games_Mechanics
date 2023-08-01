using System;
using Declarative;
using StateMachine;

namespace AtomicHomework.Hero
{
    [Serializable]
    public class HeroStates
    {
        public StateMachine.StateMachine StateMachine;

        [Section] public IdleState IdleState;
        [Section] public RunState RunState;
        [Section] public DeadState DeadState;

        [Construct]
        public void Construct(MoveSection moveSection, LifeSection lifeSection)
        {
            StateMachine.Construct(
                (HeroStateType.Idle, IdleState),
                (HeroStateType.Run, RunState),
                (HeroStateType.Dead, DeadState)
                );

            moveSection.OnMoveStarted += () => StateMachine.SwitchState(HeroStateType.Run);
            moveSection.OnMoveFinished += () => StateMachine.SwitchState(HeroStateType.Idle);
            lifeSection.OnDeath += () => StateMachine.SwitchState(HeroStateType.Dead);
        }
    }
}