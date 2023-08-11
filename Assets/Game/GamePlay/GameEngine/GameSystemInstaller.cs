using Zenject;

namespace Game.GamePlay.GameEngine
{
    public class GameSystemInstaller : MonoInstaller<GameSystemInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ConveyorModel>().FromComponentInHierarchy().AsSingle();
        }
    }
}