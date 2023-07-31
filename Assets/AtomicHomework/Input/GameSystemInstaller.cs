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
        
        public override void InstallBindings()
        {
            Container.Bind<InputSystem>().FromInstance(_inputSystem).AsSingle();
            Container.Bind<HeroEntity>().FromInstance(_heroEntity).AsSingle();
        }
    }
}