using AtomicHomework.Hero.Entity;
using Entities;
using Zenject;

namespace AtomicHomework.Services
{
    public class HeroService
    {
        private MonoEntity _hero;

        [Inject]
        public HeroService(HeroEntity hero)
        {
            _hero = hero;
        }

        public IEntity GetHero()
        {
            return _hero;
        }
    }
}