using Zenject;

namespace Game.Reward
{
    public class RewardFactory : IFactory<RewardConfig, Reward>
    {
        [Inject] private DiContainer _container;
        
        public Reward Create(RewardConfig config)
        {
            var reward = config.Create();
            _container.Inject(reward);
            return reward;
        }
    }
}