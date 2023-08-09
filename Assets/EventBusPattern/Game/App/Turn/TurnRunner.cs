using System;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace EventBusPattern
{
    public class TurnRunner : MonoBehaviour
    {
        [SerializeField] private bool _runOnStart = true;
        [SerializeField] private bool _runOnFinish = true;
        [Inject] private TurnTaskPipeline _turnTaskPipeline;

        private void Start()
        {
            if (_runOnStart)
            {
                Run();
            }
        }

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
            if (_runOnFinish)
            {
                Run();
            }
        }
    }
}