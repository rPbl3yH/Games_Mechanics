using EventBusPattern.Game.App.Effects;
using EventBusPattern.Game.GamePlay;

namespace EventBusPattern.Game.App.Events
{
    public struct DealDamageEffect : IEffect
    {
        public LifeEntity Source { get; set; }
        public LifeEntity Target { get; set; }
    }
}