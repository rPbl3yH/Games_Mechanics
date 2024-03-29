﻿using System;
using UnityEngine;

namespace StateMachine.States
{
    public enum AnimationType
    {
        Idle,
        Run,
        Shoot,
        Dead,
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
            //_animator.SetInteger(_stateId, (int)_animationType);
        }

        public void Exit()
        {
            
        }
    }
}