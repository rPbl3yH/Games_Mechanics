using AtomicProject.Core;
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
        [SerializeField] private InputSystem _inputSystem;
        [SerializeField] private HeroEntity _heroEntity;
        [SerializeField] private HeroDocument _heroDocument;
        [SerializeField] private MouseInput _mouseInput;
        
        public override void InstallBindings()
        {
            InstallMonoBehaviours();
            InstallSimple();
        }

        private void InstallMonoBehaviours()
        {
            Container.Bind<InputSystem>().FromInstance(_inputSystem).AsSingle();
            Container.Bind<HeroEntity>().FromInstance(_heroEntity).AsSingle();
            Container.Bind<HeroDocument>().FromInstance(_heroDocument).AsSingle();
            Container.Bind<MouseInput>().FromInstance(_mouseInput).AsSingle();
        }

        private void InstallSimple()
        {
            Container.Bind<HeroService>().FromNew().AsSingle();
            Container.Bind<GameFinisher>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<HeroDeathController>().FromNew().AsSingle();
        }
    }
}