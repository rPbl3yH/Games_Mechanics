using AtomicHomework.Entities.Components;
using AtomicHomework.Hero.Entity;
using AtomicHomework.Services;
using Entities;
using UnityEngine;
using Zenject;

namespace AtomicHomework.Input
{
    public class RotateController : MonoBehaviour
    {
        [Inject] private MouseInputObserver _mouseInputObserver;
        [Inject] private HeroService _heroService;

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
            if (_heroService.GetHero().TryGet(out IRotateComponent rotateComponent))
            {
                rotateComponent.Rotate(direction);
            }
        }
    }
}