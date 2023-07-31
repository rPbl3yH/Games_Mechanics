using AtomicHomework.Entities.Components;
using AtomicHomework.Hero.Entity;
using UnityEngine;
using Zenject;

namespace AtomicHomework.Input
{
    public class RotateController : MonoBehaviour
    {
        [Inject] private MouseInputObserver _mouseInputObserver;
        [Inject] private HeroEntity _heroEntity;

        private void OnEnable()
        {
            _mouseInputObserver.OnRotateDirectionChanged += OnDirectionChanged;
        }

        private void OnDisable()
        {
            _mouseInputObserver.OnRotateDirectionChanged -= OnDirectionChanged;
        }

        private void OnDirectionChanged(Vector3 direction)
        {
            if (_heroEntity.TryGet(out IRotateComponent rotateComponent))
            {
                rotateComponent.Rotate(direction);
            }
        }
    }
}