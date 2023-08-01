using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinisher 
{
    public void FinishGame()
    {
        Time.timeScale = 0f;
        Debug.Log("Finish game");
    }
}
