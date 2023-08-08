using EventBus.Game.GamePlay.Area;
using Zenject;

namespace EventBusPattern.Game.GamePlay.Installer
{
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
            Container.Bind<EventBus>().FromNew().AsSingle();
        }

        private void InstallMovementSystem()
        {
            Container.Bind<Player>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<KeyBoardInput>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<FireInput>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerInputController>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<ApplyMoveDirectionHandler>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<ApplyFireDirectionHandler>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<MoveHandler>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<DealDamageEffectHandler>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<ExplosionBarrelDeathHandler>().FromNew().AsSingle();
        }

        private void InstallAttackSystem()
        {
            Container.BindInterfacesAndSelfTo<DealDamageHandler>().FromNew().AsSingle();
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
}