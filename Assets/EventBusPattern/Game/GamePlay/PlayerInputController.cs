using System;
using EventBusPattern.Game.App.Events;
using UnityEngine;
using Zenject;

namespace EventBusPattern.Game.GamePlay
{
    public class PlayerInputController : IInitializable, IDisposable
    {
        private readonly KeyBoardInput _keyBoardInput;
        private readonly EventBus _eventBus;
        private readonly Player _player;
    
        [Inject]
        public PlayerInputController(KeyBoardInput keyBoardInput, EventBus eventBus, Player player)
        {
            _keyBoardInput = keyBoardInput;
            _eventBus = eventBus;
            _player = player;
        }

        private void OnInputPerformed(Vector3 direction)
        {
            _eventBus.RaiseEvent(new ApplyDirectionEvent(_player, direction));        
        }

        public void Initialize()
        {
            _keyBoardInput.OnInputPerformed += OnInputPerformed;
        }

        public void Dispose()
        {
            _keyBoardInput.OnInputPerformed -= OnInputPerformed;
        }
    }
}