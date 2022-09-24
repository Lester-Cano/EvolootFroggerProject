using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void GameOver();
    public event GameOver OnGameOverLost;
    public event GameOver OnGameOverWin;
    public event GameOver OnRestart;

    private Timer timer;
    private HealthController healthController;

    private void Awake()
    {
        timer = FindObjectOfType<Timer>();
        healthController = FindObjectOfType<HealthController>();
    }
    private void OnEnable()
    {
        timer.OnTimeOver += CheckIfLost;
        healthController.OnLifesOver += CheckIfLost;
    }
    private void OnDisable()
    {
        timer.OnTimeOver -= CheckIfLost;
        healthController.OnLifesOver -= CheckIfLost;
    }

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

    private void CheckIfLost()
    {
        if (healthController.withoutLives || timer.remainingDuration <= 0)
        {
            Debug.Log("2");
            HandleGameOver();
        }
    }
}
