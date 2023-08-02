using System;

namespace EventBus.Game.App
{
    public class EventBus
    {
        public void Subscribe<TEvent>(Action<TEvent> handler)
        {
        
        }

        public void Unsubscribe<TEvent>(Action<TEvent> handler)
        {
        
        }
    
        public void RaiseEvent<TEvent>(Action<TEvent> evt)
        {
            
        }
    }
}
