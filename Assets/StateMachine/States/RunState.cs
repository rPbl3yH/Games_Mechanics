using System;
using AtomicHomework.Hero;
using Declarative;

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
        }

        public void Exit()
        {
            _moveSection.OnMoveFinished -= OnMoveFinished;
        }
        
        private void OnMoveFinished()
        {
            _stateMachine.SwitchState(HeroStateType.Idle);
        }
    }
}