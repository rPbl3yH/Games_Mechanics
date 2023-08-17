using Game.Reward;
using Zenject;

namespace Game
{
    public class GameSystemInstaller : MonoInstaller<GameSystemInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<MoneyStorage>().AsSingle();
            Container.Bind<RealTimeSaveLoader>().AsSingle();
            Container.Bind<ChestRewardObserver>().AsSingle();
            Container.BindInterfacesAndSelfTo<ChestTimeRewardModule>().FromComponentInHierarchy().AsSingle();
            Container.Bind<RewardFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<ChestRewardInstaller>().FromComponentsInHierarchy().AsSingle();
        }
    }
}
