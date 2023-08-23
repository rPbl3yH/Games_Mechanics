using Entities;
using Game.GamePlay.Conveyor.Components;
using UnityEngine;
using VContainer;

namespace Game.GamePlay.Upgrades
{
    class LoadStorageUpgrade : Upgrade
    {
        private IEntity _conveyorEntity;
        private readonly LoadStorageUpgradeConfig _config;

		[Inject]
		public void Construct(IEntity entity)
        {
            Debug.Log("Inject in load storage upgrade");
            _conveyorEntity = entity;
        }

        public LoadStorageUpgrade(LoadStorageUpgradeConfig config) : base(config)
        {
            _config = config;
        }

        protected override void OnUpgrade(int newLevel)
        {
            _conveyorEntity.Get<IConveyor_SetLoadStorageComponent>().SetLoadStorage(
                _config.StorageUpgradeTable.GetLoadStorage(newLevel)
                );
        }
    }
}