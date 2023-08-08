using System;
using EventBus.Game.GamePlay;
using EventBus.Game.GamePlay.Area;
using EventBusPattern.Game.GamePlay;
using Zenject;

public class GameSystemInstaller : MonoInstaller<GameSystemInstaller>
{
    public override void InstallBindings()
    {
        InstallEventSystem();
        InstallLevelMapSystem();
        InstallAttackSystem();
        InstallMovementSystem();
        InstallEnemySystem();
    }

    private void InstallEventSystem()
    {
        Container.Bind<EventBusPattern.EventBus>().FromNew().AsSingle();
    }

    private void InstallMovementSystem()
    {
        Container.Bind<Player>().FromComponentInHierarchy().AsSingle();
        Container.BindInterfacesAndSelfTo<KeyBoardInput>().FromNew().AsSingle();
        Container.BindInterfacesAndSelfTo<PlayerInputController>().FromNew().AsSingle();
        Container.BindInterfacesAndSelfTo<ApplyDirectionHandler>().FromNew().AsSingle();
        Container.BindInterfacesAndSelfTo<MoveHandler>().FromNew().AsSingle();
    }

    private void InstallAttackSystem()
    {
        Container.BindInterfacesAndSelfTo<AttackHandler>().FromNew().AsSingle();
    }

    private void InstallLevelMapSystem()
    {
        Container.Bind<LevelMap>().FromNew().AsSingle().NonLazy();
    }

    private void InstallEnemySystem()
    {
        Container.BindInterfacesAndSelfTo<EnemySpawner>().FromComponentInHierarchy().AsSingle().NonLazy();
    }
}