using System;
using Declarative;

namespace AtomicProject.Atomic.Custom
{
    public class LateUpdateMechanics: ILateUpdateListener
    {
        private Action<float> _onLateUpdate;

        public void OnUpdate(Action<float> action)
        {
            _onLateUpdate = action;
        }

        public void LateUpdate(float deltaTime)
        {
            _onLateUpdate?.Invoke(deltaTime);
        }
    }
}