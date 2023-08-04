using AtomicProject.Entities.Components.Rotate;
using AtomicProject.Services;
using UnityEngine;
using Zenject;

namespace AtomicProject.Input
{
    public class RotateController : MonoBehaviour
    {
        [Inject] private MouseInput _mouseInputObserver;
        [Inject] private HeroService _heroService;

        private void OnEnable()
        {
            _mouseInputObserver.OnMousePointChanged += OnDirectionChanged;
        }

        private void OnDisable()
        {
            _mouseInputObserver.OnMousePointChanged -= OnDirectionChanged;
        }

        private void OnDirectionChanged(Vector3 targetPoint)
        {
            if (_heroService.GetHero().TryGet(out IRotateComponent rotateComponent))
            {
                rotateComponent.Rotate(targetPoint);
            }
        }
    }
}