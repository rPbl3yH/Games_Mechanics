using System;
using EventBus.Game.GamePlay;
using Zenject;

public class MovementSystemInstaller : MonoInstaller<MovementSystemInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<Player>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<MoveInput>().FromNew().AsSingle();
        Container.Bind<ApplyDirectionMovement>().FromNew().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<MoveController>().FromNew().AsSingle();
    }
}