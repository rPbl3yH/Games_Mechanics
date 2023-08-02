using EventBus.Game.GamePlay.Area;
using UnityEngine;
using Zenject;

public sealed class ApplyDirectionMovement 
{
    [Inject]
    private Player _player;

    [Inject] 
    private AreaService _areaService;

    public void Move(Vector3 direction)
    {
        var nextPoint = _player.transform.localPosition + direction;
            
        if (_areaService.IsWalkable(nextPoint))
        {
            _player.transform.localPosition = nextPoint;
        }
    }
}