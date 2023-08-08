namespace EventBusPattern.Game.App.Effects
{
    public interface IEffect
    {
        LifeEntity Source { get; set; }
        LifeEntity Target { get; set; }
    }
}