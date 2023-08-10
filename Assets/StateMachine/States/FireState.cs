using System;
using AtomicProject.Atomic.Actions;
using Declarative;

namespace StateMachine.States
{
    [Serializable]
    public class FireState : IState, IFixedUpdateListener
    {
        private IAtomicAction _fireRequest;
        private bool _isEnabled;

        public void Construct(IAtomicAction onFire)
        {
            _fireRequest = onFire;
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
            
            _fireRequest?.Invoke();
        }
    }
}