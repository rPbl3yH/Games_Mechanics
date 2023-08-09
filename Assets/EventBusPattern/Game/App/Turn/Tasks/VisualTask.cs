using UnityEngine;

namespace EventBusPattern
{
    public class VisualTask : Task
    {
        protected override void OnRun()
        {
            Debug.Log("Visual!");
            Finish();
        }
    }
}