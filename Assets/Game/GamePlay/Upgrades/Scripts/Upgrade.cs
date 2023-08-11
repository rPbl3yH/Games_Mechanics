using System;

namespace Game.GamePlay.Upgrades
{
    public abstract class Upgrade
    {
        public string Id => _config.Id;
        public int Level
        {
            get => _currentLevel;
            set => _currentLevel = value;
        }
        public int MaxLevel => _config.MaxLevel;
        public bool IsMaxLevel => _currentLevel == MaxLevel;
        public int NextPrice => _config.PriceTable.GetPrice(Level + 1);

        private readonly UpgradeConfig _config;

        private int _currentLevel;

        protected Upgrade(UpgradeConfig config)
        {
            _currentLevel = 1;
            _config = config;
        }

        public void LevelUp()
        {
            if (IsMaxLevel)
            {
                throw new Exception("Max level is reached!");
            }

            _currentLevel++;
            OnUpgrade(_currentLevel);
        }

        protected abstract void OnUpgrade(int newLevel);
    }
}