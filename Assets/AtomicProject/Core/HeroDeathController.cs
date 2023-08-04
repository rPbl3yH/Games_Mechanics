using System;
using AtomicProject.Entities.Components.Death;
using AtomicProject.Services;
using Zenject;

namespace AtomicProject.Core
{
    public class HeroDeathController : IInitializable, IDisposable
    {
        [Inject] private HeroService _heroService;
        [Inject] private GameFinisher _gameFinisher;

        private IDeathComponent _deathComponent;
        
        public void Initialize()
        {
            _deathComponent = _heroService.GetHero().Get<IDeathComponent>();
            _deathComponent.OnDeath += FinishGame;
        }

        private void FinishGame()
        {
            _gameFinisher.FinishGame();
        }

        public void Dispose()
        {
            _deathComponent.OnDeath -= FinishGame;
        }
    }
}