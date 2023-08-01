using System;
using UnityEngine;

namespace StateMachine
{
    public enum AnimationType
    {
        Idle,
        Run,
        Death,
        Shoot
    } 
    
    [Serializable]
    public class AnimationState : IState
    {
        [SerializeField] private AnimationType _animationType; 
        [SerializeField] private string _stateName = "State";
        
        private Animator _animator;

        private int _stateId;
        
        public void Construct(Animator animator)
        {
            _animator = animator;
            _stateId = Animator.StringToHash(_stateName);
        }
        
        public void Enter()
        {
            //TODO: set animation
        }

        public void Exit()
        {
            //TODO: set animation
        }
    }
}