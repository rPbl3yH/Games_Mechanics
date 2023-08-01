using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace StateMachine
{
    [Serializable]
    public class StateMachine : IState
    {
        [SerializeField] private HeroStateType _heroStateType;
        
        [ShowInInspector, ReadOnly]
        private IState _currentState;

        private List<(HeroStateType, IState)> _states = new();

        public void Construct(params (HeroStateType, IState)[] states)
        {
            _states = new List<(HeroStateType, IState)>(states);
        }
        
        public void Enter()
        {
            _currentState = FindState(_heroStateType);
            _currentState.Enter();
        }

        public void Exit()
        {
            _currentState.Exit();
            _currentState = null;
        }

        private IState FindState(HeroStateType type)
        {
            foreach (var tuple in _states)
            {
                if (tuple.Item1 == type)
                {
                    return tuple.Item2;
                }
            }
            
            Debug.Log("State didn't find");
            return null;
        }
    }
}