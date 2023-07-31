using AtomicHomework.Hero.Entity;
using AtomicHomework.Input;
using UnityEngine;
using Zenject;

namespace AtomicHomework.Hero
{
    public class GameSystemInstaller : MonoInstaller<GameSystemInstaller>
    {
        [SerializeField] private InputSystem _inputSystem;
        [SerializeField] private HeroEntity _heroEntity;
        [SerializeField] private MouseInputObserver _mouseInputObserver;
        [SerializeField] private HeroDocument _heroDocument;
        [SerializeField] private MouseInput _mouseInput;
        
        public override void InstallBindings()
        {
            Container.Bind<InputSystem>().FromInstance(_inputSystem).AsSingle();
            Container.Bind<HeroEntity>().FromInstance(_heroEntity).AsSingle();
            Container.Bind<MouseInputObserver>().FromInstance(_mouseInputObserver).AsSingle();
            Container.Bind<HeroDocument>().FromInstance(_heroDocument).AsSingle();
            Container.Bind<MouseInput>().FromInstance(_mouseInput).AsSingle();
        }
    }
}