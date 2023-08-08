using EventBusPattern.Game.App.Effects;
using EventBusPattern.Game.GamePlay.ExplosionBarrel;

namespace EventBusPattern.Game.App.Events
{
    public struct DealDamageEffect : IEffect
    {
        public int Damage;
        
        public void ApplyEffect()
        {
            
        }
    }
}