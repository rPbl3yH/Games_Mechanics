using Declarative;

namespace Atomic
{
    public abstract class FixedUpdateState : IState, IFixedUpdateListener
    {
        private bool enabled;

        void IState.Enter()
        {
            this.enabled = true;
            this.Enter();
        }

        void IState.Exit()
        {
            this.enabled = false;
            this.Exit();
        }

        void IFixedUpdateListener.FixedUpdate(float deltaTime)
        {
            if (this.enabled)
            {
                this.FixedUpdate(deltaTime);
            }
        }

        protected virtual void Enter()
        {
        }

        protected virtual void Exit()
        {
        }

        protected abstract void FixedUpdate(float deltaTime);
    }
}