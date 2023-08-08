using EventBusPattern.Game.App.Events;
using UnityEngine;
using Zenject;

namespace EventBusPattern
{
    public class PlayerInputTask : Task
    {
        [Inject] private readonly KeyBoardInput _keyBoardInput;
        [Inject] private readonly FireInput _fireInput;
        [Inject] private readonly EventBus _eventBus;
        [Inject] private readonly Player _player;

        protected override void OnRun()
        {
            _keyBoardInput.OnInputPerformed += OnInputPerformed;
            _fireInput.OnInputPerformed += OnFirePerformed;
        }

        private void Unsubscribe()
        {
            _keyBoardInput.OnInputPerformed -= OnInputPerformed;
            _fireInput.OnInputPerformed -= OnFirePerformed;
        }
        
        private void OnInputPerformed(Vector3 direction)
        {
            Unsubscribe();
            _eventBus.RaiseEvent(new ApplyMoveDirectionEvent(_player, direction));
            Finish();
        }

        private void OnFirePerformed(Vector3 direction)
        {
            Unsubscribe();
            _eventBus.RaiseEvent(new ApplyFireDirectionEvent(_player, direction));                
            Finish();
        }
    }
}