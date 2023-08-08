using EventBusPattern.Game.GamePlay;
using UnityEngine;

namespace EventBusPattern.Game.App.Events
{
    public struct ApplyDirectionEvent
    {
        public Character Character;
        public Vector3 Direction;

        public ApplyDirectionEvent(Character character, Vector3 direction)
        {
            Character = character;
            Direction = direction;
        }
    }
}