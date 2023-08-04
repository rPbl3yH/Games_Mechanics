using UnityEngine;

namespace AtomicProject.Core
{
    public class GameFinisher 
    {
        public void FinishGame()
        {
            Time.timeScale = 0f;
            Debug.Log("Finish game");
        }
    }
}
