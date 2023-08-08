using Zenject;

namespace EventBusPattern.Game.GamePlay.Installer
{
    public class GameSystemInstaller : MonoInstaller<GameSystemInstaller>
    {
        public override void InstallBindings()
        {
            InstallEventSystem();
            InstallTurnPipeline();
            InstallLevelMapSystem();
            InstallAttackSystem();
            InstallMovementSystem();
            InstallEnemySystem();
        }

        private void InstallTurnPipeline()
        {
            Container.Bind<TurnPipeline>().FromNew().AsSingle();
            Container.Bind<TurnRunner>().FromComponentInHierarchy().AsSingle();
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
            Container.BindInterfacesAndSelfTo<ForceDirectionEffectHandler>().FromNew().AsSingle();
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