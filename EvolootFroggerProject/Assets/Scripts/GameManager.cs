using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void GameOver();
    public event GameOver OnGameOverLost;
    public event GameOver OnGameOverWin;

    private Restart restart;

    private void Awake()
    {
        restart = FindObjectOfType<Restart>();
    }
}
