using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EventBusPattern
{
    public class EventBus
    {
        private Dictionary<Type, IEventHandlerCollection> _handlers = new();

        private Queue<object> _eventQueue = new();
        private bool _isRunning;
        
        public void Subscribe<TEvent>(Action<TEvent> handler)
        {
            var eventType = typeof(TEvent);

            _handlers.TryAdd(eventType, new EventHandlerEventCollection<TEvent>());

            _handlers[eventType].Subscribe(handler);
        }

        public void Unsubscribe<TEvent>(Action<TEvent> handler)
        {
            var eventType = typeof(TEvent);

            if (_handlers.TryGetValue(eventType, out var handlers))
            {
                handlers.Unsubscribe(handler);
            }
        }
    
        public void RaiseEvent<TEvent>(TEvent evt)
        {
            if (_isRunning)
            {
                _eventQueue.Enqueue(evt);
                return;
            }
            
            _isRunning = true;
            
            var eventType = evt.GetType();
            Debug.Log(eventType);

            if (!_handlers.TryGetValue(eventType, out var eventHandlerCollection))
            {
                Debug.Log("No subscribers found");
            }

            eventHandlerCollection?.RaiseEvent(evt);

            _isRunning = false;

            if (_eventQueue.Any())
            {
                RaiseEvent(_eventQueue.Dequeue());
            }
        }
    }

    public interface IEventHandlerCollection
    {
        public void Subscribe(Delegate handler);
        public void Unsubscribe(Delegate handler);
        public void RaiseEvent<TEvent>(TEvent evt);
    }
    
    public sealed class EventHandlerEventCollection<T> : IEventHandlerCollection
    {
        private readonly List<Delegate> _handlers = new ();

        private int _currentIndex = -1;

        public void Subscribe(Delegate handler)
        {
            _handlers.Add(handler);
        }

        public void Unsubscribe(Delegate handler)
        {
            var index = _handlers.IndexOf(handler);
            _handlers.RemoveAt(index);

            if (index <= _currentIndex)
            {
                _currentIndex--;
            }
        }

        public void RaiseEvent<TEvent>(TEvent evt)
        {
            if (evt is not T concreteEvent)
            {
                return;
            }

            for (_currentIndex = 0; _currentIndex < _handlers.Count; _currentIndex++)
            {
                var action = (Action<T>)_handlers[_currentIndex];
                action?.Invoke(concreteEvent);
            }
        }
    }
}
