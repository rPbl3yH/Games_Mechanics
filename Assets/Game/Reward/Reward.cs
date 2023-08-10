using System;
using Zenject;

namespace Game.Reward
{
    [Serializable]
    public abstract class Reward
    {
        public virtual void Construct(DiContainer container)
        {
            
        }

        public abstract void ReceiveReward();
    }
}