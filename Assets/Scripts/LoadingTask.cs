using System.Collections;
using UnityEngine;

public class LoadingTask : MonoBehaviour
{
    [SerializeField] private CoroutineSequencer _coroutineSequencer;
    [SerializeField] private string _taskNumberText;

    private void Awake()
    {
        _coroutineSequencer.AddLoadingTask(FirstCoroutine());
    }

    private IEnumerator FirstCoroutine()
    {
        Debug.Log($"{_taskNumberText} task started");
        yield return new WaitForSeconds(1);
        Debug.Log($"{_taskNumberText} task completed");
        
    }
}



