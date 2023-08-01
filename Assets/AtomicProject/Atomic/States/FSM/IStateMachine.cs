using System;

namespace Atomic
{
    public interface IStateMachine<TKey> : IState
    {
        event Action<TKey> OnStateSwitched;

        TKey CurrentState { get; }

        void SwitchState(TKey key);
    }
}