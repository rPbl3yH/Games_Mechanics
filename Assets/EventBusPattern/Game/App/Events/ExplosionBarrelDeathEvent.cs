using EventBusPattern.Game.GamePlay.ExplosionBarrel;
using UnityEngine;

namespace EventBusPattern.Game.App.Events
{
    public struct ExplosionBarrelDeathEvent
    {
        public ExplosionBarrel Barrel;

        public ExplosionBarrelDeathEvent(ExplosionBarrel barrel)
        {
            Barrel = barrel;
        }
    }
}