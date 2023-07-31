using System;
using System.Collections.Generic;
using System.Linq;
using Declarative;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Atomic
{
    [Serializable]
    public class StateMachine<TKey> : State, IStateMachine<TKey>, IDisposable
    {
        public event Action<TKey> OnStateSwitched
        {
            add { this.onStateSwitched += value; }
            remove { this.onStateSwitched -= value; }
        }

        public TKey CurrentState
        {
            get { return this.currentKey; }
        }

        [OnValueChanged("SwitchState")]
        [Space, ShowInInspector, LabelText("Current State"), PropertyOrder(-10)]
        private TKey currentKey;

        private IState currentState;
        private Dictionary<TKey, IState> states = new();
        private Action<TKey> onStateSwitched;

        public virtual void SwitchState(TKey key)
        {
            if (this.currentState != null)
            {
                this.currentState.Exit();
            }

            this.currentKey = key;
            
            if (this.states.TryGetValue(this.currentKey, out this.currentState))
            {
                this.currentState.Enter();
            }

            this.onStateSwitched?.Invoke(key);
        }

        [Title("Methods")]
        [Button, GUIColor(0, 1, 0)]
        public override void Enter()
        {
            if (this.currentState == null && this.states.TryGetValue(this.currentKey, out this.currentState))
            {
                this.currentState.Enter();
            }
        }

        [Button, GUIColor(0, 1, 0)]
        public override void Exit()
        {
            if (this.currentState != null)
            {
                this.currentState.Exit();
                this.currentState = null;
            }
        }

        public void SetupStates(params (TKey, IState)[] states)
        {
            this.states = states.ToDictionary(it => it.Item1, it => it.Item2);
        }

        public void SetupCurrentState(TKey key)
        {
            this.currentKey = key;
        }

        public void AddState(TKey key, IState state)
        {
            this.states[key] = state;
        }

        public void RemoveState(TKey key)
        {
            this.states.Remove(key);
        }

        public void Clear()
        {
            this.states.Clear();
        }

        public void Dispose()
        {
            DelegateUtils.Dispose(ref this.onStateSwitched);
        }
    }
}