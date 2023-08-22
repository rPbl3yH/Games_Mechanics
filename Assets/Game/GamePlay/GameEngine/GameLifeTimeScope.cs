using Entities;
using Game.GamePlay.Upgrades;
using VContainer;
using VContainer.Unity;

namespace Game.GamePlay.GameEngine
{
    public class GameLifeTimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInHierarchy<IEntity>();
            builder.RegisterComponentInHierarchy<IMoneyStorage>();
        }
    }
}