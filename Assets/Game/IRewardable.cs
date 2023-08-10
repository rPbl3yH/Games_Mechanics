using System;
using System.Collections.Generic;

namespace Game
{
    public interface IRewardable
    {
        List<Reward.Reward> Rewards { get; set; }
        event Action<IRewardable> OnRewardReceived;
    }
}