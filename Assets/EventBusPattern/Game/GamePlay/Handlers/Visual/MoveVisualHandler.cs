using EventBusPattern.Game.App.Events;
using UnityEngine;

namespace EventBusPattern.Visual
{
    public class MoveVisualHandler : BaseHandler<MoveEvent>
    {
        protected override void OnHandleEvent(MoveEvent evt)
        {
            Debug.Log(nameof(MoveVisualHandler));
        }
    }
}