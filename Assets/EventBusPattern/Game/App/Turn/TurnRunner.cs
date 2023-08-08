using System;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace EventBusPattern
{
    public class TurnRunner : MonoBehaviour
    {
        [Inject] private TurnPipeline _turnPipeline;

        private void OnEnable()
        {
            _turnPipeline.OnFinished += OnFinished;
        }

        private void OnDisable()
        {
            _turnPipeline.OnFinished -= OnFinished;
        }

        [Button]
        public void Run()
        {
            _turnPipeline.Run();
        }

        private void OnFinished()
        {
            print("Finish pipline");
        }
    }
}