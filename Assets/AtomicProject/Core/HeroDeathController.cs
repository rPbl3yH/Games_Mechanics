using AtomicHomework.Services;
using UnityEngine;
using Zenject;

namespace AtomicHomework.Entities.Components
{
    public class HeroDeathController : MonoBehaviour
    {
        [Inject] private HeroService _heroService;
        [Inject] private GameFinisher _gameFinisher;
        
        private void Start()
        {
            var component = _heroService.GetHero().Get<DeathComponent>();
            component.OnDeath += FinishGame;
        }
        
        private void FinishGame()
        {
            _gameFinisher.FinishGame();
        }
    }
}