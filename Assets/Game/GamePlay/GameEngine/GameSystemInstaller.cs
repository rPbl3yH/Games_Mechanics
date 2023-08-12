using Entities;
using Game.GamePlay.Conveyor;
using Zenject;

namespace Game.GamePlay.GameEngine
{
    public class GameSystemInstaller : MonoInstaller<GameSystemInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IEntity>().To<ConveyorEntity>().FromComponentInHierarchy().AsSingle();
        }
    }
}