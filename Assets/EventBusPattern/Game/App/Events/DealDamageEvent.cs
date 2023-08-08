using EventBusPattern.Game.GamePlay;

namespace EventBusPattern.Game.App.Events
{
    public struct DealDamageEvent
    {
        public LifeEntity Source;
        public LifeEntity Target;

        public DealDamageEvent(LifeEntity source, LifeEntity target)
        {
            Source = source;
            Target = target;
        }
    }
}