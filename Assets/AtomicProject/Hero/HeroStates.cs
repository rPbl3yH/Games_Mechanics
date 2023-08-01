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
        public void Construct()
        {
            StateMachine.Construct(
                (HeroStateType.Idle, IdleState),
                (HeroStateType.Run, RunState)
                );
        }
    }
}