using Entities;
using Game.GamePlay.Conveyor.Components;
using Zenject;

namespace Game.GamePlay.Upgrades
{
    class LoadStorageUpgrade : Upgrade
    {
        [Inject] private IEntity _conveyorModel;
        
        public LoadStorageUpgrade(UpgradeConfig config) : base(config)
        {
            
        }

        protected override void OnUpgrade(int newLevel)
        {
            _conveyorModel.Get<IConveyor_SetLoadStorageComponent>().SetLoadStorage(newLevel);
        }
    }
}