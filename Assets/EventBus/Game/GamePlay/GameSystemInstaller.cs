using System;
using EventBus.Game.GamePlay;
using EventBus.Game.GamePlay.Area;
using Zenject;

public class GameSystemInstaller : MonoInstaller<GameSystemInstaller>
{
    public override void InstallBindings()
    {
        InstallAreaSystem();
        InstallMovementSystem();
        InstallEnemySystem();
    }

    private void InstallMovementSystem()
    {
        Container.Bind<Player>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<MoveInput>().FromNew().AsSingle();
        Container.BindInterfacesAndSelfTo<ApplyDirectionMovement>().FromNew().AsSingle().NonLazy();
    }

    private void InstallAreaSystem()
    {
        Container.Bind<AreaService>().FromNew().AsSingle().NonLazy();
    }

    private void InstallEnemySystem()
    {
        Container.BindInterfacesAndSelfTo<EnemySpawner>().FromComponentInHierarchy().AsSingle().NonLazy();
    }
}