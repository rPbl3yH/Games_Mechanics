using System;
using EventBus.Game.GamePlay.Area;
using UnityEngine;
using Zenject;

public sealed class ApplyDirectionMovement :  IDisposable
{
    private Transform _transform;

    [Inject] 
    private AreaService _areaService;
    
    private readonly MoveInput _moveInput;

    [Inject]
    public ApplyDirectionMovement(MoveInput moveInput, Player player)
    {
        _moveInput = moveInput;
        _transform = player.transform;
        _moveInput.OnDirectionChanged += Move;
    }

    private void Move(Vector3 direction)
    {
        var nextPoint = _transform.localPosition + direction;
            
        if (_areaService.IsWalkable(nextPoint))
        {
            _transform.LookAt(nextPoint);
            _transform.localPosition = nextPoint;
        }
    }

    public void Dispose()
    {
        _moveInput.OnDirectionChanged -= Move;
    }
}