using UnityEngine;

namespace EventBusPattern
{
    public class StartTask : Task
    {
        protected override void OnRun()
        {
            Debug.Log("Start turn task");
            Finish();
        }
    }

    public class FinishTask : Task
    {
        protected override void OnRun()
        {
            Debug.Log("Finish turn task");
            Finish();
        }
    }
}