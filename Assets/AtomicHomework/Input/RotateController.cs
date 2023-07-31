using AtomicHomework.Hero;
using UnityEngine;

namespace AtomicHomework.Input
{
    public class RotateController : MonoBehaviour
    {
        [SerializeField] private MouseInputObserver _mouseInputObserver;
        [SerializeField] private HeroDocument _document;

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