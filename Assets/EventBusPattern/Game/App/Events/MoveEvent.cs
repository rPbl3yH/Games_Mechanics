using EventBusPattern.Game.GamePlay;
using UnityEngine;

namespace EventBusPattern.Game.App.Events
{
    public struct MoveEvent
    {
        public readonly Character Character;
        public Vector3 TargetPoint;

        public MoveEvent(Character character, Vector3 targetPoint)
        {
            Character = character;
            TargetPoint = targetPoint;
        }
    }
}