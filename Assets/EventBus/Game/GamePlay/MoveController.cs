using System;
using UnityEngine;
using Zenject;

namespace EventBus.Game.GamePlay
{
    public sealed class MoveController : IDisposable
    {
        private readonly MoveInput _moveInput;
        private readonly PlayerMovement _playerMovement;

        [Inject]
        public MoveController(MoveInput moveInput, PlayerMovement playerMovement)
        {
            _moveInput = moveInput;
            _playerMovement = playerMovement;
            _moveInput.OnDirectionChanged += OnDirectionChanged;
            Debug.Log("Init move controller");
        }

        private void OnDirectionChanged(Vector3 direction)
        {
            _playerMovement.Move(direction);
        }

        public void Dispose()
        {
            _moveInput.OnDirectionChanged -= OnDirectionChanged;
        }
    }
}