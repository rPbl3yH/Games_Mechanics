using System;
using Zenject;

namespace Game.Reward
{
    [Serializable]
    public abstract class Reward
    {
        public abstract void ReceiveReward();
    }
}