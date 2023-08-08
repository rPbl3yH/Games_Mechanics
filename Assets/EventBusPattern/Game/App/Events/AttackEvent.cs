using EventBusPattern.Game.GamePlay;

namespace EventBusPattern.Game.App.Events
{
    public struct AttackEvent
    {
        public Character Source;
        public Character Target;

        public AttackEvent(Character source, Character target)
        {
            Source = source;
            Target = target;
        }
    }
}