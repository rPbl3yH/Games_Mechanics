using UnityEngine;

namespace Game.GamePlay.Upgrades
{
    public class TestPurchase : MonoBehaviour
    {
        [SerializeField] private string _upgradeID;

        private UpgradesContext _upgradesContext;
        private UpgradePurchaser _upgradePurchaser;

        public void Construct(UpgradesContext upgradesContext, UpgradePurchaser upgradePurchaser)
        {
            _upgradePurchaser = upgradePurchaser;
            _upgradesContext = upgradesContext;
        }

        public void Purchase()
        {
            Upgrade upgrade = _upgradesContext.GetUpgradeBy(_upgradeID);
            if (upgrade != null)
            {
                bool purchaseResult = _upgradePurchaser.TryPurchase(upgrade);
                Debug.Log($"Purchase result: {purchaseResult}");
            }
        }
    }
}