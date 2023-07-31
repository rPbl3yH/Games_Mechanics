using AtomicHomework.Hero;
using UnityEngine;
using Zenject;

namespace AtomicHomework.Input
{
    public class RotateController : MonoBehaviour
    {
        [Inject] private MouseInputObserver _mouseInputObserver;
        [Inject] private HeroDocument _document;

        private void Awake()
        {
            _mouseInputObserver.OnRotateDirectionChanged += OnDirectionChanged;
        }

        private void OnDestroy()
        {
            _mouseInputObserver.OnRotateDirectionChanged += OnDirectionChanged;
        }

        private void OnDirectionChanged(Vector3 direction)
        {
            _document.Rotate.Direction.Value = direction;
        }
    }
}