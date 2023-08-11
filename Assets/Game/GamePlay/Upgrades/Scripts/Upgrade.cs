using System;

namespace Game.GamePlay.Upgrades
{
    public abstract class Upgrade
    {
        public string Id
        {
            get { return config.Id; }
        }

        public int Level
        {
            get { return currentLevel; }
            set { currentLevel = value; }
        }

        public int MaxLevel
        {
            get { return config.MaxLevel; }
        }

        public bool IsMaxLevel
        {
            get { return currentLevel == MaxLevel; }
        }
    
        public int NextPrice
        {
            get { return config.PriceTable.GetPrice(Level + 1); }
        }

        private readonly UpgradeConfig config;

        private int currentLevel;
        
        public Upgrade(UpgradeConfig config)
        {
            currentLevel = 1;
            this.config = config;
        }

        public void LevelUp()
        {
            if (IsMaxLevel)
            {
                throw new Exception("Max level is reached!");
            }

            currentLevel++;
            OnUpgrade(currentLevel);
        }

        protected abstract void OnUpgrade(int newLevel);
    }
}