using System;
using EventBus.Game.GamePlay;
using EventBus.Game.GamePlay.Area;
using Zenject;

public class MovementSystemInstaller : MonoInstaller<MovementSystemInstaller>
{
    public override void InstallBindings()
    {
        InstallAreaSystem();
        InstallMovementSystem();
    }

    private void InstallMovementSystem()
    {
        Container.Bind<Player>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<MoveInput>().FromNew().AsSingle();
        Container.Bind<ApplyDirectionMovement>().FromNew().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<MoveController>().FromNew().AsSingle();
    }

    private void InstallAreaSystem()
    {
        Container.Bind<AreaService>().FromNew().AsSingle().NonLazy();
    }
}