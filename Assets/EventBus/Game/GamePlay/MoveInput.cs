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
        if (Input.GetKeyDown(KeyCode.A))
        {
            OnDirectionChanged?.Invoke(Vector3.left);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            OnDirectionChanged?.Invoke(Vector3.right);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            OnDirectionChanged?.Invoke(Vector3.forward);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            OnDirectionChanged?.Invoke(Vector3.back);
        }
    }
}