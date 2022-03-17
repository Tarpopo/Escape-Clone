using UnityEngine;

public class GameState : MonoBehaviour
{
    public void SetPause(bool isPause) => Time.timeScale = isPause ? 0 : 1;
}