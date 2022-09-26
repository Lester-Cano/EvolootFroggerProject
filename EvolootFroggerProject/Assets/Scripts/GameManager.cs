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
    private PlayerController playerController;
    private PlayerMovement PlayerMovement;

    private void Awake()
    {
        timer = FindObjectOfType<Timer>();
        healthController = FindObjectOfType<HealthController>();
        playerController = FindObjectOfType<PlayerController>();
        PlayerMovement = FindObjectOfType<PlayerMovement>();
    }
    private void OnEnable()
    {
        timer.OnTimeOver += CheckIfLost;
        healthController.OnLifesOver += CheckIfLost;
        playerController.OnReachEnd += HandleWin;
    }
    private void OnDisable()
    {
        timer.OnTimeOver -= CheckIfLost;
        healthController.OnLifesOver -= CheckIfLost;
        playerController.OnReachEnd -= HandleWin;
    }

    public void HanldeRestartGame()
    {
        timer.OnEnable();
        healthController.OnEnable();
        playerController.OnEnable();
        PlayerMovement.OnEnable();
        OnRestart?.Invoke();
    }

    public void HandleGameOver()
    {
        timer.OnDisable();
        healthController.OnDisable();
        playerController.OnDisable();
        PlayerMovement.OnDisable();
        OnGameOverLost?.Invoke();
    }

    public void HandleWin()
    {
        timer.OnDisable();
        healthController.OnDisable();
        playerController.OnDisable();
        PlayerMovement.OnDisable();
        OnGameOverWin?.Invoke();
    }

    private void CheckIfLost()
    {
        HandleGameOver();
    }
}
