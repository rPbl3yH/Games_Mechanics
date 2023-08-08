using System;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace EventBusPattern
{
    public class TurnRunner : MonoBehaviour
    {
        [Inject] private TurnTaskPipeline _turnTaskPipeline;

        private void OnEnable()
        {
            _turnTaskPipeline.OnFinished += OnFinished;
        }

        private void OnDisable()
        {
            _turnTaskPipeline.OnFinished -= OnFinished;
        }

        [Button]
        public void Run()
        {
            _turnTaskPipeline.Run();
        }

        private void OnFinished()
        {
            
        }
    }
}