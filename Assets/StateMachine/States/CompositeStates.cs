using System.Collections.Generic;

namespace StateMachine
{
    public class CompositeState : IState
    {
        private List<IState> _states = new();

        public void Enter()
        {
            foreach (var state in _states)
            {
                state.Enter();
            }
        }

        public void Exit()
        {
            foreach (var state in _states)
            {
                state.Exit();
            }
        }

        protected void SetStates(params IState[] states)
        {
            _states = new List<IState>(states);
        }
    }
}