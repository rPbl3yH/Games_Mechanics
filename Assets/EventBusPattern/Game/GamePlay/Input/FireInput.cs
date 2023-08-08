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
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                OnInputPerformed?.Invoke(Vector3.left);            
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                OnInputPerformed?.Invoke(Vector3.right);
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                OnInputPerformed?.Invoke(Vector3.forward);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                OnInputPerformed?.Invoke(Vector3.back);
            }
        }
    }
}