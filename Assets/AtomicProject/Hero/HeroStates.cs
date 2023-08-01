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
        public void Construct()
        {
            StateMachine.Construct(
                (HeroStateType.Idle, IdleState),
                (HeroStateType.Run, RunState)
                );
        }
    }
}