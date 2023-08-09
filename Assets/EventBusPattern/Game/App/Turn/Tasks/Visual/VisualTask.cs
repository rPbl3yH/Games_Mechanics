using EventBusPattern.Visual;
using UnityEngine;
using Zenject;

namespace EventBusPattern
{
    public class VisualTask : Task
    {
        [Inject] private VisualTaskPipeline _visualTaskPipeline;
        
        protected override void OnRun()
        {
            Debug.Log("Visual started!");
            _visualTaskPipeline.OnFinished += OnFinished;
            _visualTaskPipeline.Run();
        }

        private void OnFinished()
        {
            Debug.Log("Visual finished");
            _visualTaskPipeline.OnFinished -= OnFinished;
            _visualTaskPipeline.Clear();
            Finish();
        }
    }
}