using System;
using UnityEngine;
using Zenject;

namespace EventBusPattern
{
    public class FireInput : ITickable
    {
        public Action<Vector3> OnInputPerformed;
    
        public void Tick()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.LeftArrow))
            {
                OnInputPerformed?.Invoke(Vector3.left);            
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.RightArrow))
            {
                OnInputPerformed?.Invoke(Vector3.right);
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.UpArrow))
            {
                OnInputPerformed?.Invoke(Vector3.forward);
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.DownArrow))
            {
                OnInputPerformed?.Invoke(Vector3.back);
            }
        }
    }
}