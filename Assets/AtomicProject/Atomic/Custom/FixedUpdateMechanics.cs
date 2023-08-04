using System;
using Declarative;

namespace AtomicProject.Atomic.Custom
{
    public class FixedUpdateMechanics : IFixedUpdateListener
    {
        private Action<float> _onLateUpdate;

        public void OnUpdate(Action<float> action)
        {
            _onLateUpdate = action;
        }

        public void FixedUpdate(float deltaTime)
        {
            _onLateUpdate?.Invoke(deltaTime);
        }
    }
}