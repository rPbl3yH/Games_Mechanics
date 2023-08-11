using UnityEngine;

namespace EventBusPattern.Game.App.Events
{
    public struct SpawnEntityEvent
    {
        public LifeEntity LifeEntity;
        public Vector2Int SpawnPoint;

        public SpawnEntityEvent(LifeEntity lifeEntity, Vector2Int spawnPoint)
        {
            LifeEntity = lifeEntity;
            SpawnPoint = spawnPoint;
        }
    }
}