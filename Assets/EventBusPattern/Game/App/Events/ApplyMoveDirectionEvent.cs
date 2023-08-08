using UnityEngine;

namespace EventBusPattern.Game.App.Events
{
    public struct ApplyMoveDirectionEvent
    {
        public LifeEntity LifeEntity;
        public Vector3 Direction;

        public ApplyMoveDirectionEvent(LifeEntity lifeEntity, Vector3 direction)
        {
            LifeEntity = lifeEntity;
            Direction = direction;
        }
    }
}