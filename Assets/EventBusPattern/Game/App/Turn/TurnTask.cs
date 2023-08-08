using System;

namespace EventBusPattern
{
    public abstract class TurnTask
    {
        private Action<TurnTask> _callback;
        
        public void Run(Action<TurnTask> callBack)
        {
            _callback = callBack;
            OnRun();
        }

        protected abstract void OnRun();

        protected virtual void Finish()
        {
            if (_callback is not null)
            {
                var callback = _callback;
                _callback = null;
                 
                callback?.Invoke(this);
            }
        }

        protected virtual void OnFinish()
        {
            
        }
    }
}