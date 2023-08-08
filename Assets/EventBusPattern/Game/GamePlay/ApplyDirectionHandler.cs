using System;
using EventBus.Game.App.Events;
using EventBus.Game.GamePlay.Area;
using UnityEngine;
using Zenject;

public sealed class ApplyDirectionHandler :  IInitializable, IDisposable
{
    [Inject] 
    private LevelMap _levelMap;

    [Inject] private AttackHandler _attackHandler;
    [Inject] private MoveHandler _moveHandler;

    private readonly Player _player;
    private readonly Transform _transform;
    private readonly EventBusPattern.EventBus _eventBus;
    
    [Inject]
    public ApplyDirectionHandler(EventBusPattern.EventBus eventBus, Player player)
    {
        _player = player;
        _eventBus = eventBus;
        _transform = player.transform;
    }
    
    public void Initialize()
    {
        _eventBus.Subscribe<ApplyDirectionEvent>(OnApplyDirection);
    }

    public void Dispose()
    {
        _eventBus.Unsubscribe<ApplyDirectionEvent>(OnApplyDirection);
    }
    
    private void OnApplyDirection(ApplyDirectionEvent evt)
    {
        var nextPoint = _transform.localPosition + evt.Direction;
            
        if (_levelMap.IsWalkable(nextPoint))
        {
            _eventBus.RaiseEvent(new MoveEvent(_player, nextPoint));
            //_moveController.Move(_player, nextPoint);
        }
        else
        {
            if (_levelMap.HasCharacter(nextPoint))
            {
                var target = _levelMap.GetCharacter(nextPoint);
                _eventBus.RaiseEvent(new AttackEvent(_player, target));
                // _attackHandler.Attack(_player, target);            
            }
        }
    }
}