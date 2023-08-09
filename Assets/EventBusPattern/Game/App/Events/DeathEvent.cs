namespace EventBusPattern.Game.App.Events
{
    public struct DeathEvent
    {
        public LifeEntity LifeEntity;

        public DeathEvent(LifeEntity lifeEntity)
        {
            LifeEntity = lifeEntity;
        }
    }
}