using Zenject;

namespace Game.GamePlay.Upgrades
{
    class LoadStorageUpgrade : Upgrade
    {
        private readonly LoadStorageUpgradeConfig config;
        
        [Inject] private ConveyorModel _conveyorModel;

        public LoadStorageUpgrade(LoadStorageUpgradeConfig config) : base(config)
        {
            this.config = config;
        }

        protected override void OnUpgrade(int newLevel)
        {
            _conveyorModel.LoadStorageCapacity.Value = config.StorageUpgradeTable.GetLoadStorage(newLevel);
        }
    }
}