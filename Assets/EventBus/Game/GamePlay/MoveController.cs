using System;
using UnityEngine;
using Zenject;

namespace EventBus.Game.GamePlay
{
    public sealed class MoveController : IDisposable
    {
        private readonly MoveInput _moveInput;
        private readonly ApplyDirectionMovement _applyDirectionMovement;

        [Inject]
        public MoveController(MoveInput moveInput, ApplyDirectionMovement applyDirectionMovement)
        {
            _moveInput = moveInput;
            _applyDirectionMovement = applyDirectionMovement;
            _moveInput.OnDirectionChanged += OnDirectionChanged;
            Debug.Log("Init move controller");
        }

        private void OnDirectionChanged(Vector3 direction)
        {
            _applyDirectionMovement.Move(direction);
        }

        public void Dispose()
        {
            _moveInput.OnDirectionChanged -= OnDirectionChanged;
        }
    }
}