using Entities;
using Game.GamePlay.Conveyor;
using Game.GamePlay.Upgrades;
using Zenject;

namespace Game.GamePlay.GameEngine
{
    public class GameSystemInstaller : MonoInstaller<GameSystemInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IEntity>().To<ConveyorEntity>().FromComponentInHierarchy().AsSingle();
            Container.Bind<IMoneyStorage>().To<MoneyStorage>().FromComponentInHierarchy().AsSingle();
        }
    }
}