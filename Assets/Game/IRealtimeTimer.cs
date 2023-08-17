using System;

namespace Game
{
    public interface IRealtimeTimer
    {
        event Action<IRealtimeTimer> OnStarted;
        
        string Id { get; }
        
        void Synchronize(float offlineSeconds);
    }
}