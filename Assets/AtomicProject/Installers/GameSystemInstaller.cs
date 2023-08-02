using AtomicHomework.Atomic.Enemy.Document;
using AtomicHomework.Hero.Entity;
using AtomicHomework.Input;
using AtomicHomework.Services;
using UnityEngine;
using Zenject;

namespace AtomicHomework.Hero
{
    public class GameSystemInstaller : MonoInstaller<GameSystemInstaller>
    {
        [SerializeField] private InputSystem _inputSystem;
        [SerializeField] private HeroEntity _heroEntity;
        [SerializeField] private HeroDocument _heroDocument;
        [SerializeField] private MouseInput _mouseInput;
        [SerializeField] private EnemyFindService _enemyFindService;
        [SerializeField] private EnemySpawner _enemySpawner;
        
        public override void InstallBindings()
        {
            InstallMonoBehaviours();
            InstallEnemyManagement();
            InstallSimple();
        }

        private void InstallMonoBehaviours()
        {
            Container.Bind<InputSystem>().FromInstance(_inputSystem).AsSingle();
            Container.Bind<HeroEntity>().FromInstance(_heroEntity).AsSingle();
            Container.Bind<HeroDocument>().FromInstance(_heroDocument).AsSingle();
            Container.Bind<MouseInput>().FromInstance(_mouseInput).AsSingle();
        }

        private void InstallEnemyManagement()
        {
            Container.Bind<EnemySpawner>().FromInstance(_enemySpawner).AsSingle();
            Container.Bind<EnemyService>().FromNew().AsSingle();
            Container.Bind<EnemyFindService>().FromInstance(_enemyFindService).AsSingle();
        }

        private void InstallSimple()
        {
            Container.Bind<HeroService>().FromNew().AsSingle();
            Container.Bind<GameFinisher>().FromNew().AsSingle();
        }
    }
}