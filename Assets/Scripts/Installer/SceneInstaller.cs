using ShootEmUp;
using Zenject;

public class SceneInstaller : MonoInstaller<SceneInstaller>
{
    public override void InstallBindings() {
        Container.Bind<GameManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<BulletLauncher>().FromComponentInHierarchy().AsSingle();
        Container.Bind<EnemyFactory>().FromComponentInHierarchy().AsSingle();
        Container.Bind<LevelBounds>().FromComponentInHierarchy().AsSingle();
        Container.Bind<BulletFactory>().FromComponentInHierarchy().AsSingle();
    }
}