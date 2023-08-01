using System;
using AtomicHomework.Hero;
using Declarative;
using UnityEngine;

namespace StateMachine
{
    [Serializable]
    public class RunState : IState
    {        
        private Animator _animator;
        private MoveSection _moveSection;
        
        [Construct]
        public void Construct(MoveSection moveSection)
        {
            _moveSection = moveSection;
        }
            
        [Construct]
        public void Construct(HeroVisual heroVisual)
        {
            _animator = heroVisual.Animator;
        }
        
        public void Enter()
        {
            //TODO: set run animation
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