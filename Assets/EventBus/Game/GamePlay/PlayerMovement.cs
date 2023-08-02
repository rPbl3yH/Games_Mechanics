using UnityEngine;
using Zenject;

public sealed class PlayerMovement 
{
    [Inject]
    private Player _player;

    public void Move(Vector3 direction)
    {
        _player.transform.localPosition += direction * Time.deltaTime;
    }
}