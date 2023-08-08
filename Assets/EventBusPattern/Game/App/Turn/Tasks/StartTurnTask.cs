using UnityEngine;

namespace EventBusPattern
{
    public class StartTurnTask : TurnTask
    {
        protected override void OnRun()
        {
            Debug.Log("Start turn task");
            Finish();
        }
    }

    public class FinishTurnTask : TurnTask
    {
        protected override void OnRun()
        {
            Debug.Log("Finish turn task");
            Finish();
        }
    }
}