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
        [Inject] private TaskPipeline _taskPipeline;

        private void Start()
        {
            if (_runOnStart)
            {
                Run();
            }
        }

        private void OnEnable()
        {
            _taskPipeline.OnFinished += OnFinished;
        }

        private void OnDisable()
        {
            _taskPipeline.OnFinished -= OnFinished;
        }

        [Button]
        public void Run()
        {
            _taskPipeline.Run();
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