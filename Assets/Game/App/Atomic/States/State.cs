using System;

namespace Game.App.Atomic.States
{
    [Serializable]
    public class State : IState
    {
        public virtual void Enter()
        {
        }

        public virtual void Exit()
        {
        }
    }
}