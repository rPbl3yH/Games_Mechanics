using EventBus.Game.GamePlay.Area;
using UnityEngine;

namespace EventBus.Game.App.Events
{
    public struct MoveEvent
    {
        public Character Character;
        public Vector3 TargetPoint;

        public MoveEvent(Character character, Vector3 targetPoint)
        {
            Character = character;
            TargetPoint = targetPoint;
        }
    }
}