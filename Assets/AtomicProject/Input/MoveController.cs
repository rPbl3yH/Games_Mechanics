using AtomicProject.Entities.Components.Move;
using AtomicProject.Services;
using UnityEngine;
using Zenject;

namespace AtomicProject.Input
{
    public class MoveController : MonoBehaviour
    {
        [Inject] private InputSystem _input;
        [Inject] private HeroService _heroService;

        private void OnEnable()
        {
            _input.OnDirectionChanged += OnDirectionChanged;
        }

        private void OnDisable()
        {
            _input.OnDirectionChanged -= OnDirectionChanged;
        }

        private void OnDirectionChanged(Vector3 direction)
        {
            if(_heroService.GetHero().TryGet(out IMoveComponent component))
            {
                component.Move(direction);
            }
        }
    }
}