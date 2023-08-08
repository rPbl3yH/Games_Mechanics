using EventBusPattern.Game.GamePlay;
using UnityEngine;

namespace EventBusPattern.Game.App.Events
{
    public struct ApplyFireDirectionEvent
    {
        public Character Character;
        public Vector3 Direction;

        public ApplyFireDirectionEvent(Character character, Vector3 direction)
        {
            Character = character;
            Direction = direction;
        }
    }
}