namespace EventBusPattern.Game.App.Effects
{
    public struct ForceDirectionEffect : IEffect
    {
        public LifeEntity Source { get; set; }
        public LifeEntity Target { get; set; }
    }
}