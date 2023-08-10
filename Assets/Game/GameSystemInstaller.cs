using Game;
using Zenject;

public class GameSystemInstaller : MonoInstaller<GameSystemInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<MoneyStorage>().FromComponentInHierarchy().AsSingle();
    }
}
