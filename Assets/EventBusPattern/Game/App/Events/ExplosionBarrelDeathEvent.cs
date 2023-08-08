using EventBusPattern.Game.GamePlay.ExplosionBarrel;

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