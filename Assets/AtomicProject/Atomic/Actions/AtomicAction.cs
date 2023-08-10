using Sirenix.OdinInspector;

namespace AtomicProject.Atomic.Actions
{
    public sealed class AtomicAction : IAtomicAction
    {
        private System.Action action;

        public AtomicAction(System.Action action)
        {
            this.action = action;
        }

        public AtomicAction()
        {
            
        }
        
        public void Use(System.Action action)
        {
            this.action = action;
        }

        [Button]
        public void Invoke()
        {
            this.action?.Invoke();
        }
    }

    public sealed class AtomicAction<T> : IAtomicAction<T>
    {
        private System.Action<T> action;

        public AtomicAction(System.Action<T> action)
        {
            this.action = action;
        }

        public AtomicAction()
        {
            
        }

        public void Use(System.Action<T> action)
        {
            this.action = action;
        }

        [Button]
        public void Invoke(T args)
        {
            this.action?.Invoke(args);
        }
    }
}