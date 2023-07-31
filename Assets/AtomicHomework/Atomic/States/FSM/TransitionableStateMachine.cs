using System;
using System.Collections.Generic;
using Declarative;

namespace Atomic
{
    [Serializable]
    public class TransitionableStateMachine<TKey> : StateMachine<TKey>, IUpdateListener
    {
        private List<(TKey, Func<bool>)> orderedTransitions = new();

        public void SetupTransitions(params (TKey, Func<bool>)[] transitions)
        {
            this.orderedTransitions = new List<(TKey, Func<bool>)>(transitions);
        }

        void IUpdateListener.Update(float deltaTime)
        {
            this.UpdateTransitions();
        }

        private void UpdateTransitions()
        {
            for (int i = 0, count = this.orderedTransitions.Count; i < count; i++)
            {
                var (key, predicate) = this.orderedTransitions[i];

                if (predicate.Invoke())
                {
                    if (!key.Equals(this.CurrentState))
                    {
                        this.SwitchState(key);                        
                    }
                    return;
                }
            }
        }
    }
}