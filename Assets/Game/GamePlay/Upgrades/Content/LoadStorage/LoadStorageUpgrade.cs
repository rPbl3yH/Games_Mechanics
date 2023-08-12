using Entities;
using Game.GamePlay.Conveyor.Components;
using Zenject;

namespace Game.GamePlay.Upgrades
{
    class LoadStorageUpgrade : Upgrade
    {
        [Inject] private IEntity _conveyorModel;
        private readonly LoadStorageUpgradeConfig _config;

        public LoadStorageUpgrade(LoadStorageUpgradeConfig config) : base(config)
        {
            _config = config;
        }

        protected override void OnUpgrade(int newLevel)
        {
            _conveyorModel.Get<IConveyor_SetLoadStorageComponent>().SetLoadStorage(
                _config.StorageUpgradeTable.GetLoadStorage(newLevel)
                );
        }
    }
}