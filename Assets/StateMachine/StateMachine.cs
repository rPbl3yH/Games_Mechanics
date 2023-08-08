using System;
using System.Collections.Generic;
using Declarative;
using Sirenix.OdinInspector;
using StateMachine.States;
using UnityEngine;

namespace StateMachine
{
    [Serializable]
    public class StateMachine<T> : IState
    {
        public event Action<T> OnStateSwitched; 

        [ShowInInspector] 
        public T CurrentStateType;

        [SerializeField] private bool _enterOnStart;

        [ShowInInspector, ReadOnly]
        private IState _currentState;

        private List<(T, IState)> _states = new();

        public void Construct(params (T, IState)[] states)
        {
            _states = new List<(T, IState)>(states);
        }

        public void Enter()
        {
            _currentState = FindState(CurrentStateType);
            _currentState.Enter();
        }

        public void Exit()
        {
            _currentState.Exit();
            _currentState = null;
        }

        public virtual void SwitchState(T type)
        {
            Exit();
            CurrentStateType = type;
            Enter();
            OnStateSwitched?.Invoke(type);
        }

        private IState FindState(T type)
        {
            foreach (var tuple in _states)
            {
                if (tuple.Item1.Equals(type))
                {
                    return tuple.Item2;
                }
            }
            
            Debug.Log("State didn't find");
            return null;
        }
    }
}