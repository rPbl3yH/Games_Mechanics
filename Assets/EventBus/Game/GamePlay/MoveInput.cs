using System;
using UnityEngine;
using Zenject;

public class MoveInput : ITickable
{
    public Action<Vector3> OnDirectionChanged;

    public MoveInput()
    {
        Debug.Log("Init move input");
    }

    public void Tick()
    {
        //Debug.Log("Tick Move Input");
        if (Input.GetKey(KeyCode.A))
        {
            OnDirectionChanged?.Invoke(Vector3.left);
        }

        if (Input.GetKey(KeyCode.D))
        {
            OnDirectionChanged?.Invoke(Vector3.right);
        }

        if (Input.GetKey(KeyCode.W))
        {
            OnDirectionChanged?.Invoke(Vector3.forward);
        }

        if (Input.GetKey(KeyCode.S))
        {
            OnDirectionChanged?.Invoke(Vector3.back);
        }
    }
}