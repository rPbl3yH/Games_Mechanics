using System;
using Declarative;
using Sirenix.OdinInspector;
using UnityEngine;
using Object = System.Object;

namespace AtomicProject.Atomic.Values
{
    [Serializable]
    public class AtomicVariable<T> : IAtomicVariable<T>, IDisposable
    {
        public event Action<T> OnChanged
        {
            add { this.onChanged += value; }
            remove { this.onChanged -= value; }
        }

        public T Value
        {
            get { return this.value; }
            set
            {
                this.value = value;
                this.onChanged?.Invoke(value);
            }
        }

        private Action<T> onChanged;

        [OnValueChanged("OnValueChanged")]
        [SerializeField]
        private T value;

        public AtomicVariable()
        {
            this.value = default;
        }

        public AtomicVariable(T value)
        {
            this.value = value;
        }

#if UNITY_EDITOR
        private void OnValueChanged(T value)
        {
            this.onChanged?.Invoke(value);
        }
#endif
        public void Dispose()
        {
            DelegateUtils.Dispose(ref this.onChanged);
        }
    }

    public class DelegateUtils
    {
        public static void Dispose<T>(ref Action<T> onChanged)
        {
            
        }
        
        public static void Dispose(ref Action onChanged)
        {
            
        }
    }
}