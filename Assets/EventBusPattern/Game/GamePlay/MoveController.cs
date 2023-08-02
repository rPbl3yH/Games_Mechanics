using EventBus.Game.GamePlay.Area;
using UnityEngine;

public class MoveController
{
    public void Move(Character character, Vector3 nextPoint)
    {
        character.transform.LookAt(nextPoint);
        character.transform.localPosition = nextPoint;
    }
}