using UnityEngine;

namespace Game.GamePlay.Upgrades.Content
{
    [CreateAssetMenu(menuName = "Create ProduceTimeUpgradeConfig", fileName = "ProduceTimeUpgradeConfig", order = 0)]
    public class ProduceTimeUpgradeConfig : UpgradeConfig
    {
        public ProduceTimeUpgradeTable ProduceTimeUpgradeTable;
        
        public override Upgrade InstantiateUpgrade()
        {
            return new ProduceTimeUpgrade(this);
        }

        private void OnValidate()
        {
            ProduceTimeUpgradeTable.OnValidate(MaxLevel);
        }
    }
}