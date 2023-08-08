using EventBusPattern.Game.GamePlay;
using UnityEngine;

namespace EventBusPattern.Game.App.Events
{
    public struct MoveEvent
    {
        public readonly LifeEntity LifeEntity;
        public Vector3 TargetPoint;

        public MoveEvent(LifeEntity lifeEntity, Vector3 targetPoint)
        {
            LifeEntity = lifeEntity;
            TargetPoint = targetPoint;
        }
    }
}