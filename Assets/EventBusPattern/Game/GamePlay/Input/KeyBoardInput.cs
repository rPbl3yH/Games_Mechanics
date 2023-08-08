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
            if (Input.GetKeyDown(KeyCode.A))
            {
                OnInputPerformed?.Invoke(Vector3.left);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                OnInputPerformed?.Invoke(Vector3.right);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                OnInputPerformed?.Invoke(Vector3.forward);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                OnInputPerformed?.Invoke(Vector3.back);
            }
        }
    }
}