using System;

namespace Atomic
{
    public interface IAtomicProcess
    {
        event Action OnStarted;
        event Action OnStopped;

        bool IsPlaying { get; }
        
        bool CanStart();
        void Start();
        void Stop();
    }
    
    public interface IAtomicProcess<T>
    {
        event Action<T> OnStarted;
        event Action<T> OnStopped;

        bool IsPlaying { get; }
        T State { get; }

        bool CanStart(T state);
        void Start(T state);
        void Stop();
    }
}