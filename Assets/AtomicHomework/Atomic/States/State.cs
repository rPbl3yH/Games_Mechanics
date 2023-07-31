using System;

namespace Atomic
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