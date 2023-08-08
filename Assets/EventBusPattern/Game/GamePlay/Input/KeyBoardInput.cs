using System;
using UnityEngine;
using Zenject;

namespace EventBusPattern
{
    public class KeyBoardInput : ITickable
    {
        public Action<Vector3> OnInputPerformed;

        public void Tick()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.A))
            {
                OnInputPerformed?.Invoke(Vector3.left);
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.D))
            {
                OnInputPerformed?.Invoke(Vector3.right);
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.W))
            {
                OnInputPerformed?.Invoke(Vector3.forward);
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.S))
            {
                OnInputPerformed?.Invoke(Vector3.back);
            }
        }
    }
}