using UnityEngine;

namespace EventBusPattern.Game.App.Events
{
    public struct MoveEvent
    {
        public readonly LifeEntity LifeEntity;
        public Vector3 TargetPoint;
        public float Duration;

        public MoveEvent(LifeEntity lifeEntity, Vector3 targetPoint, float duration)
        {
            LifeEntity = lifeEntity;
            TargetPoint = targetPoint;
            Duration = duration;
        }
    }
}