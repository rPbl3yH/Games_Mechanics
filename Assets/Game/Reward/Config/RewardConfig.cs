using UnityEngine;
using Zenject;

namespace Game.Reward
{
    public abstract class RewardConfig : ScriptableObject
    {
        public abstract Reward Create();
    }
}