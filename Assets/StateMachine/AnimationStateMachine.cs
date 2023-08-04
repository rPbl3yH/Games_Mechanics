using System;
using UnityEngine;

namespace StateMachine
{
    [Serializable]
    public class AnimationStateMachine<T> : StateMachine<T> where T : Enum
    {
        private readonly string _key = "State";
        [SerializeField] private Animator _animator;

        public override void SwitchState(T type)
        {
            base.SwitchState(type);
            _animator.SetInteger(Animator.StringToHash(_key), Convert.ToInt32(type));
        }
    }
}