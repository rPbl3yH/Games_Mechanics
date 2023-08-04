using System;
using System.Collections.Generic;
using Declarative;
using UnityEngine;

namespace StateMachine
{
    [Serializable]
    public class AnimationStateMachine<T> : StateMachine<T>, IUpdateListener where T : Enum
    {
        private readonly string _key = "State";
        [SerializeField] private Animator _animator;

        private List<(T, Func<bool>)> _transitions = new();

        public override void SwitchState(T type)
        {
            base.SwitchState(type);
            _animator.SetInteger(Animator.StringToHash(_key), Convert.ToInt32(type));
        }

        public void AddTransition(T type, Func<bool> condition)
        {
            _transitions.Add((type, condition));
        }

        public void Update(float deltaTime)
        {
            foreach (var (stateType, condition) in _transitions)
            {
                if (!stateType.Equals(CurrentStateType) && condition.Invoke())
                {
                    SwitchState(CurrentStateType);
                }
            }
        }
    }
}