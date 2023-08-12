using Entities;
using Game.GamePlay.Conveyor.Components;
using Zenject;

namespace Game.GamePlay.Upgrades
{
    class LoadStorageUpgrade : Upgrade
    {
        private readonly LoadStorageUpgradeConfig config;
        
        [Inject] private IEntity _conveyorModel;

        public LoadStorageUpgrade(LoadStorageUpgradeConfig config) : base(config)
        {
            this.config = config;
        }

        protected override void OnUpgrade(int newLevel)
        {
            _conveyorModel.Get<IConveyor_SetLoadStorage>().SetLoadStorage(newLevel);
        }
    }
}