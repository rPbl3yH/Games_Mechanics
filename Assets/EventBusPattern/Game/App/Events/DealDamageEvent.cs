using EventBusPattern.Game.GamePlay;

namespace EventBusPattern.Game.App.Events
{
    public struct DealDamageEvent
    {
        public Character Source;
        public Character Target;

        public DealDamageEvent(Character source, Character target)
        {
            Source = source;
            Target = target;
        }
    }
}