using System;
using AtomicProject.Atomic.Actions;
using Declarative;

namespace StateMachine.States
{
    [Serializable]
    public class FireState : IState, IFixedUpdateListener
    {
        private AtomicEvent _onFire;
        private bool _isEnabled;

        public void Construct(AtomicEvent onFire)
        {
            _onFire = onFire;
        }
        
        public void Enter()
        {
            _isEnabled = true;
        }

        public void Exit()
        {
            _isEnabled = false;
        }

        public void FixedUpdate(float deltaTime)
        {
            if (!_isEnabled)
            {
                return;
            }
            
            _onFire?.Invoke();
        }
    }
}