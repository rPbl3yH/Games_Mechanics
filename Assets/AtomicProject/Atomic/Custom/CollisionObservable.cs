using System;
using Declarative;
using UnityEngine;

namespace Atomic
{
    public sealed class CollisionObservable : MonoBehaviour, IDisposable
    {
        public event Action<Collision> OnEntered
        {
            add { this.onEntered += value; }
            remove { this.onEntered -= value; }
        }

        public event Action<Collision> OnExited
        {
            add { this.onExited += value; }
            remove { this.onExited -= value; }
        }

        private Action<Collision> onEntered;
        private Action<Collision> onExited;

        private void OnCollisionEnter(Collision collision)
        {
            this.onEntered.Invoke(collision);
        }

        private void OnCollisionExit(Collision collision)
        {
            this.onExited.Invoke(collision);
        }

        public void Dispose()
        {
            DelegateUtils.Dispose(ref this.onEntered);
            DelegateUtils.Dispose(ref this.onExited);
        }
    }
}