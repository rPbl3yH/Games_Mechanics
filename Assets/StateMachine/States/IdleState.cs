using System;
using AtomicHomework.Hero;
using Declarative;
using UnityEngine;

namespace StateMachine
{
    [Serializable]
    public class IdleState : IState
    {
        private Animator _animator;

        [Construct]
        public void Construct(HeroVisual heroVisual)
        {
            _animator = heroVisual.Animator;
        }
        
        public void Enter()
        {
            //TODO: set idle animation
        }

        public void Exit()
        {
        }
    }
}