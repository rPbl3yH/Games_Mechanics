using Entities;
using Game.GamePlay.Conveyor.Components;
using Zenject;

namespace Game.GamePlay.Upgrades.Content
{
    public class ProduceTimeUpgrade : Upgrade
    {
        [Inject] private IEntity _conveyorModel;
        private readonly ProduceTimeUpgradeConfig _config;

        public ProduceTimeUpgrade(ProduceTimeUpgradeConfig config) : base(config)
        {
            _config = config;
        }

        protected override void OnUpgrade(int newLevel)
        {
            _conveyorModel.Get<IConveyor_SetProduceTimeComponent>().SetProduceTime(
                _config.ProduceTimeUpgradeTable.GetProduceTime(newLevel)
            );
        }
    }
}