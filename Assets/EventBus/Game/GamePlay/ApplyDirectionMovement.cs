using System;
using EventBus.Game.GamePlay.Area;
using UnityEngine;
using Zenject;

public sealed class ApplyDirectionMovement :  IDisposable
{
    [Inject]
    private Player _player;

    [Inject] 
    private AreaService _areaService;
    
    private readonly MoveInput _moveInput;

    [Inject]
    public ApplyDirectionMovement(MoveInput moveInput)
    {
        _moveInput = moveInput;
        _moveInput.OnDirectionChanged += Move;
    }

    public void Move(Vector3 direction)
    {
        var nextPoint = _player.transform.localPosition + direction;
            
        if (_areaService.IsWalkable(nextPoint))
        {
            _player.transform.localPosition = nextPoint;
        }
    }

    public void Dispose()
    {
        _moveInput.OnDirectionChanged -= Move;
    }
}