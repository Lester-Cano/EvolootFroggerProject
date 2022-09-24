using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void GameOver();
    public event GameOver OnGameOverLost;
    public event GameOver OnGameOverWin;
    public event GameOver OnRestart;

    private void HanldeRestartGame()
    {
        OnRestart?.Invoke();
    }

    private void HandleGameOver()
    {
        OnGameOverLost?.Invoke();
    }

    private void HandleWin()
    {
        OnGameOverWin?.Invoke();
    }
}
