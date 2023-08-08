using System;
using EventBusPattern.Game.App.Events;
using UnityEngine;
using Zenject;

namespace EventBusPattern.Game.GamePlay
{
    public class PlayerInputController : IInitializable, IDisposable
    {
        private readonly KeyBoardInput _keyBoardInput;
        private readonly FireInput _fireInput;
        private readonly EventBus _eventBus;
        private readonly Player _player;
    
        [Inject]
        public PlayerInputController(FireInput fireInput, KeyBoardInput keyBoardInput, EventBus eventBus, Player player)
        {
            _fireInput = fireInput;
            _keyBoardInput = keyBoardInput;
            _eventBus = eventBus;
            _player = player;
        }

        public void Initialize()
        {
            _keyBoardInput.OnInputPerformed += OnInputPerformed;
            _fireInput.OnInputPerformed += OnFirePerformed;
        }
        
        private void OnInputPerformed(Vector3 direction)
        {
            _eventBus.RaiseEvent(new ApplyMoveDirectionEvent(_player, direction));        
        }

        private void OnFirePerformed(Vector3 direction)
        {
            _eventBus.RaiseEvent(new ApplyFireDirectionEvent(_player, direction));                
        }

        public void Dispose()
        {
            _keyBoardInput.OnInputPerformed -= OnInputPerformed;
            _fireInput.OnInputPerformed -= OnFirePerformed;
        }
    }
}