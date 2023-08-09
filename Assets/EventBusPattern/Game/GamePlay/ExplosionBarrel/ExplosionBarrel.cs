using EventBusPattern.Game.App.Effects;
using EventBusPattern.Game.App.Events;
using UnityEngine;

namespace EventBusPattern.Game.GamePlay.ExplosionBarrel
{
    public class ExplosionBarrel : LifeEntity
    {
        [SerializeReference] public IEffect[] EffectsOnDeath;
    }
}