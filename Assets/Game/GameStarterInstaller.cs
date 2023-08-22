using Zenject;

namespace Game
{
    public class GameStarterInstaller : MonoInstaller<GameStarterInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<GameStarter>().FromComponentInHierarchy().AsSingle();
        }
    }
}