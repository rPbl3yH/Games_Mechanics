using AtomicProject.Core;
using AtomicProject.Enemy;
using AtomicProject.Hero;
using AtomicProject.Hero.Entity;
using AtomicProject.Input;
using AtomicProject.Services;
using UnityEngine;
using Zenject;

namespace AtomicProject.Installers
{
    public class GameSystemInstaller : MonoInstaller<GameSystemInstaller>
    {
        public override void InstallBindings()
        {
            InstallMonoBehaviours();
            InstallEnemyManagement();
            InstallSimple();
        }

        private void InstallMonoBehaviours()
        {
            Container.Bind<InputSystem>().FromComponentInHierarchy().AsSingle();
            Container.Bind<HeroEntity>().FromComponentInHierarchy().AsSingle();
            Container.Bind<HeroDocument>().FromComponentInHierarchy().AsSingle();
            Container.Bind<MouseInput>().FromComponentInHierarchy().AsSingle();
        }

        private void InstallEnemyManagement()
        {
            Container.Bind<EnemySpawner>().FromComponentInHierarchy().AsSingle();
            Container.Bind<EnemyService>().FromNew().AsSingle();
            Container.Bind<EnemyFindService>().FromComponentInHierarchy().AsSingle();
        }

        private void InstallSimple()
        {
            Container.Bind<HeroService>().FromNew().AsSingle();
            Container.Bind<GameFinisher>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<HeroDeathController>().FromNew().AsSingle();
        }
    }
}