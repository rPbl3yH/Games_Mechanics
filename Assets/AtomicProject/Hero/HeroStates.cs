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
        [Section] public ShootState ShootState;

        [Construct]
        public void Construct(HeroCore heroCore)
        {
            StateMachine.Construct(
                (HeroStateType.Idle, IdleState),
                (HeroStateType.Run, RunState),
                (HeroStateType.Dead, DeadState),
                (HeroStateType.Shoot, ShootState)
                );

            heroCore.MoveSection.OnMoveStarted += () => StateMachine.SwitchState(HeroStateType.Run);
            heroCore.MoveSection.OnMoveFinished += () => StateMachine.SwitchState(HeroStateType.Idle);
            heroCore.LifeSection.OnDeath += () => StateMachine.SwitchState(HeroStateType.Dead);
            heroCore.FireSection.OnFire += () => StateMachine.SwitchState(HeroStateType.Shoot);
        }
    }
}