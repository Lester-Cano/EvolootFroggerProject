using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void GameOver();
    public event GameOver OnGameOverLost;
    public event GameOver OnGameOverWin;
    public event GameOver OnRestart;

    public void HanldeRestartGame()
    {
        OnRestart?.Invoke();
    }

    public void HandleGameOver()
    {
        OnGameOverLost?.Invoke();
    }

    public void HandleWin()
    {
        OnGameOverWin?.Invoke();
    }
}
