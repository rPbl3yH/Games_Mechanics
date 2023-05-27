﻿using UnityEngine;

public class CharacterMoveController : MonoBehaviour, IGameStartListener, IGameFinishListener
{
    [SerializeField] private MoveComponent _moveComponent;
    [SerializeField] private MoveInput _moveInput;
    private RoadSide _roadSide;

    void IGameStartListener.OnGameStarted() {
        _roadSide = RoadSide.Middle;
        _moveInput.OnMove += OnMoveHorizontal;
    }

    void IGameFinishListener.OnGameFinished() {
        _moveInput.OnMove -= OnMoveHorizontal;
    }

    private void OnMoveHorizontal(InputDirection inputDirection) {
        if(inputDirection == InputDirection.Left && _roadSide == RoadSide.Left) {
            return;
        }

        if(inputDirection == InputDirection.Right && _roadSide == RoadSide.Right) {
            return; 
        }

        UpdateRoadSide(inputDirection);

        var dx = inputDirection == InputDirection.Left ? Vector3.left.x : Vector3.right.x;
        _moveComponent.MoveHorizonral(dx);
    }

    private void UpdateRoadSide(InputDirection inputDirection) {
        if(_roadSide == RoadSide.Left) {
            _roadSide = RoadSide.Middle;
        }
        else if (_roadSide == RoadSide.Middle) {
            _roadSide = inputDirection == InputDirection.Left ? RoadSide.Left : RoadSide.Right;
        }
        else if (_roadSide == RoadSide.Right) {
            _roadSide = RoadSide.Middle;
        }
    }
}
