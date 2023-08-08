using EventBusPattern.Game.GamePlay;
using UnityEngine;

namespace EventBusPattern.Game.App.Events
{
    public struct ApplyMoveDirectionEvent
    {
        public Character Character;
        public Vector3 Direction;

        public ApplyMoveDirectionEvent(Character character, Vector3 direction)
        {
            Character = character;
            Direction = direction;
        }
    }
}