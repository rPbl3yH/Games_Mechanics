using System;
using UnityEngine;
using Zenject;

namespace AtomicHomework.Input
{
    public class MouseInputObserver : MonoBehaviour
    {
        [Inject] private MouseInput _mouseInput;
        
        public event Action<Vector3> OnRotateDirectionChanged;

        private void Awake()
        {
            _mouseInput.OnDirectionChanged += OnDirectionChanged;
        }

        private void OnDirectionChanged(Vector2 direction)
        {
            var rotateDirection = new Vector3(0f, direction.x, 0f);
            OnRotateDirectionChanged?.Invoke(rotateDirection);
        }
    }
}