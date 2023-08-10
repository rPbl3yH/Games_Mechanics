using System;
using Declarative;
using StateMachine.States;
using UnityEngine;

namespace AtomicProject.Hero
{
    [Serializable]
    public class HeroStates
    {
        public StateMachine.StateMachine<HeroStateType> StateMachine;

        [Section] public IdleState IdleState;
        [Section] public RunState RunState;
        [Section] public DeadState DeadState;
        [Section] public ShootState ShootState;

        [Construct]
        public void Construct(HeroDocument heroDocument, HeroCore heroCore)
        {
            StateMachine.Construct(
                (HeroStateType.Idle, IdleState),
                (HeroStateType.Run, RunState),
                (HeroStateType.Dead, DeadState),
                (HeroStateType.Shoot, ShootState)
                );

            heroCore.MoveSection.OnMoveStarted += () => StateMachine.SwitchState(HeroStateType.Run);
            heroCore.MoveSection.OnMoveFinished += () =>
            {
                if (heroCore.FindEnemySection.IsFind.Value)
                {
                    StateMachine.SwitchState(HeroStateType.Shoot);
                }
                else
                {
                    StateMachine.SwitchState(HeroStateType.Idle);
                }
            };
            heroCore.LifeSection.OnDeath += () => StateMachine.SwitchState(HeroStateType.Dead);

            heroDocument.onStart += () => StateMachine.Enter();
        }
    }
}