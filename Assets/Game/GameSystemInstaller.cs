using Game.Reward;
using Zenject;

namespace Game
{
    public class GameSystemInstaller : MonoInstaller<GameSystemInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<MoneyStorage>().FromNew().AsSingle();
            Container.Bind<RealTimeSaveLoader>().FromNew().AsSingle();
            Container.Bind<RealTimeRewardReceiver>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<TimeRewardModule>().FromComponentInHierarchy().AsSingle();
            Container.Bind<RewardFactory>().AsSingle();
        }
    }
}
