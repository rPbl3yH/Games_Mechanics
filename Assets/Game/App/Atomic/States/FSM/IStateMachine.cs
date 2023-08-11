using System;

namespace Game.App.Atomic.States.FSM
{
    public interface IStateMachine<TKey> : IState
    {
        event Action<TKey> OnStateSwitched;

        TKey CurrentState { get; }

        void SwitchState(TKey key);
    }
}