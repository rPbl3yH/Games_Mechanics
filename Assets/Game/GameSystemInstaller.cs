using Zenject;

namespace Game
{
    public class GameSystemInstaller : MonoInstaller<GameSystemInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<MoneyStorage>().FromComponentInHierarchy().AsSingle();
            Container.Bind<RealTimeSaveLoader>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<TimeRewardModule>().FromComponentInHierarchy().AsSingle();
        }
    }
}
