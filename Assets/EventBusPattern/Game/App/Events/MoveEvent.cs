using EventBus.Game.GamePlay.Area;
using UnityEngine;

namespace EventBus.Game.App.Events
{
    public class MoveEvent
    {
        private Character _character;
        private Vector3 _targetPoint;

        public MoveEvent(Character character, Vector3 targetPoint)
        {
            _character = character;
            _targetPoint = targetPoint;
        }
    }
}