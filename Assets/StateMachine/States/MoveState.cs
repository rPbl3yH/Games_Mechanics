using System;
using AtomicProject.Hero;
using UnityEngine;

namespace StateMachine.States
{
    [Serializable]
    public class MoveState : IState
    {
        private MoveSection _moveSection;

        public void Construct(MoveSection moveSection)
        {
            _moveSection = moveSection;
        }
        
        public void Enter()
        {
            _moveSection.OnMove += SetDirection;
        }

        public void Exit()
        {
            _moveSection.OnMove -= SetDirection;
            SetDirection(Vector3.zero);
        }

        private void SetDirection(Vector3 direction)
        {
            _moveSection.Direction.Value = direction;
        }
    }
}