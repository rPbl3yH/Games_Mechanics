using System;
using AtomicHomework.Hero;
using Declarative;
using UnityEngine;

namespace StateMachine
{
    [Serializable]
    public class RunState : IState
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
            _moveSection.OnMoveFinished += OnMoveFinished;
            _moveSection.OnMove += SetDirection;
            //TODO: set run animation
        }

        public void Exit()
        {
            _moveSection.OnMoveFinished -= OnMoveFinished;
            _moveSection.OnMove -= SetDirection;
            SetDirection(Vector3.zero);
        }

        public void SetDirection(Vector3 direction)
        {
            _moveSection.Direction.Value = direction;
        }
        
        private void OnMoveFinished()
        {
            _stateMachine.SwitchState(HeroStateType.Idle);
        }
    }
}