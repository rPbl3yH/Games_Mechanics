using EventBusPattern.Game.GamePlay;
using UnityEngine;

namespace EventBusPattern.Game.App.Events
{
    public struct ApplyFireDirectionEvent
    {
        public LifeEntity LifeEntity;
        public Vector3 Direction;

        public ApplyFireDirectionEvent(LifeEntity lifeEntity, Vector3 direction)
        {
            LifeEntity = lifeEntity;
            Direction = direction;
        }
    }
}