using EventBus.Game.GamePlay.Area;

namespace EventBus.Game.App.Events
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