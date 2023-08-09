using EventBusPattern.Game.GamePlay.Handlers.Logic;
using EventBusPattern.Visual;
using Zenject;

namespace EventBusPattern.Game.GamePlay.Installer
{
    public class GameSystemInstaller : MonoInstaller<GameSystemInstaller>
    {
        public override void InstallBindings()
        {
            InstallEventBus();
            InstallTurnPipeline();
            InstallLevelMapSystem();
            InstallPlayer();
            InstallHandlers();
            InstallEnemySystem();
            InstallVisualPipeline();
        }

        private void InstallTurnPipeline()
        {
            Container.Bind<TaskPipeline>().FromNew().AsSingle();
            Container.Bind<TurnRunner>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<TurnPipelineInstaller>().FromNew().AsSingle();
        }

        private void InstallVisualPipeline()
        {
            Container.Bind<VisualTaskPipeline>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<MoveVisualHandler>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<DeathVisualHandler>().FromNew().AsSingle();
        }

        private void InstallEventBus()
        {
            Container.Bind<EventBus>().FromNew().AsSingle();
        }

        private void InstallHandlers()
        {
            Container.BindInterfacesAndSelfTo<ApplyMoveDirectionHandler>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<ApplyFireDirectionHandler>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<MoveHandler>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<DealDamageEffectHandler>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<ExplosionBarrelDeathHandler>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<ForceDirectionEffectHandler>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<DealDamageHandler>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<DeathHandler>().FromNew().AsSingle();
            
        }

        private void InstallPlayer()
        {
            Container.Bind<Player>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<KeyBoardInput>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<FireInput>().FromNew().AsSingle();
        }

        private void InstallLevelMapSystem()
        {
            Container.Bind<LevelMap>().FromNew().AsSingle().NonLazy();
        }

        private void InstallEnemySystem()
        {
            Container.BindInterfacesAndSelfTo<EnemySpawner>().FromComponentInHierarchy().AsSingle();
        }
    }
}