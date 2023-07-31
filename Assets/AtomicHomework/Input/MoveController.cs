using AtomicHomework.Entities.Components;
using AtomicHomework.Hero.Entity;
using UnityEngine;
using Zenject;

namespace AtomicHomework.Input
{
    public class MoveController : MonoBehaviour
    {
        [Inject] private InputSystem _input;
        [Inject] private HeroEntity _heroEntity;

        private void OnEnable()
        {
            _input.OnDirectionChanged += OnDirectionChanged;
        }

        private void OnDestroy()
        {
            _input.OnDirectionChanged -= OnDirectionChanged;
        }

        private void OnDirectionChanged(Vector3 direction)
        {
            if(_heroEntity.TryGet(out IMoveComponent component))
            {
                component.Move(direction);
            }
        }
    }
}