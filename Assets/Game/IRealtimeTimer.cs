using System;

namespace Game
{
    public interface IRealtimeTimer
    {
        event Action<IRealtimeTimer> OnStarted;
        event Action<IRealtimeTimer> OnFinish;
        
        string Id { get; }
        
        void Synchronize(float offlineSeconds);
    }
}