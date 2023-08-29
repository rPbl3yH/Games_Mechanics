using Game;
using Game.Reward;
using VContainer;
using VContainer.Unity;

public class SceneLifeTimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<MoneyStorage>(Lifetime.Singleton);
        builder.RegisterFactory<RewardConfig, Reward>(container => {
            return config =>
            {
                var reward = config.Create();
                container.Inject(reward);
                return reward;
            };
        }, Lifetime.Singleton);

        builder.Register<RealTimeSaveLoader>(Lifetime.Singleton);
        builder.Register<ChestRewardReceiver>(Lifetime.Singleton);

        builder.RegisterComponentInHierarchy<Game.Scopes.ChestInstaller>();
        builder.RegisterComponentInHierarchy<Game.Scopes.ChestInstaller>().AsImplementedInterfaces();
        builder.RegisterComponentInHierarchy<GameStarter>();
    }
}
