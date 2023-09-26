using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class CoroutineSequencer : MonoBehaviour
{
    private List<IEnumerator> _tasks = new List<IEnumerator>();

    public void AddLoadingTask(IEnumerator enumerator)
    {
        _tasks.Add(enumerator);
    }

    [Button("Start loading")]
    public void Load()
    {
        StartCoroutine(LoadingTaskCoroutine());
    }
    
    private IEnumerator LoadingTaskCoroutine()
    {
        foreach (var task in _tasks)
        {
            yield return StartCoroutine(task);
        }

        Debug.Log("Coroutine pipeline finished");
    }
}



