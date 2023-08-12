using Entities;
using Game.GamePlay.Conveyor.Components;
using Zenject;

namespace Game.GamePlay.Upgrades.Content
{
    public class UnloadStorageUpgrade : Upgrade
    {
        [Inject] private IEntity _conveyorModel;
        private readonly UnloadStorageUpgradeConfig _config;
        public UnloadStorageUpgrade(UnloadStorageUpgradeConfig config) : base(config)
        {
            _config = config;
        }

        protected override void OnUpgrade(int newLevel)
        {
            _conveyorModel.Get<IConveyor_SetUnloadStorageComponent>().SetUnloadStorage(
                _config.StorageUpgradeTable.GetUnloadStorage(newLevel)
                );
        }
    }
}