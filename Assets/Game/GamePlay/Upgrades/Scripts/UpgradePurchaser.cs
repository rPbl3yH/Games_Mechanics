using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GamePlay.Upgrades
{
    public sealed class UpgradePurchaser : MonoBehaviour
    {
        [ShowInInspector, ReadOnly] private IMoneyStorage _moneyStorage;

        public void Construct(IMoneyStorage moneyStorage)
        {
            _moneyStorage = moneyStorage;
        }

        public bool CanPurchase(Upgrade upgrade)
        {
            if (upgrade.IsMaxLevel)
            {
                return false;
            }

            return _moneyStorage.CanSpendMoney(upgrade.NextPrice);
        }

        public bool TryPurchase(Upgrade upgrade)
        {
            if (CanPurchase(upgrade) == false)
            {
                return false;
            }
            
            _moneyStorage.SpendMoney(upgrade.NextPrice);
            upgrade.LevelUp();
            return true;
        }
    }
}