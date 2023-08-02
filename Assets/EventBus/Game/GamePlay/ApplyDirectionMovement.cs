using UnityEngine;
using Zenject;

public sealed class ApplyDirectionMovement 
{
    [Inject]
    private Player _player;

    private float _distance = 5f;

    public void Move(Vector3 direction)
    {
        _player.transform.localPosition += direction;
    }
}