using System;
using AtomicHomework.Hero;
using Declarative;
using UnityEngine;

namespace StateMachine
{
    [Serializable]
    public class IdleState : IState
    {
        private StateMachine _stateMachine;
        private MoveSection _moveSection;
        
        [Construct]
        public void Construct(MoveSection moveSection, HeroStates states)
        {
            _stateMachine = states.StateMachine;
            _moveSection = moveSection;
        }
        
        public void Enter()
        {
            _moveSection.OnMoveStarted += OnMoveStarted;
        }

        public void Exit()
        {
            _moveSection.OnMoveStarted -= OnMoveStarted;
        }

        public void OnMoveStarted()
        {
            _stateMachine.SwitchState(HeroStateType.Run);
        }
    }
}