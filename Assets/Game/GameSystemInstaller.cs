using Game.Reward;
using Zenject;

namespace Game
{
    public class GameSystemInstaller : MonoInstaller<GameSystemInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<MoneyStorage>().AsSingle();
            Container.BindFactory<RewardConfig, Reward.Reward, RewardFactory>();
        }
    }
}
