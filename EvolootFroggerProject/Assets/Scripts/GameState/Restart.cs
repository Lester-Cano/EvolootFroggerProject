using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    public delegate void RestartGame();
    public event RestartGame OnRestart;

    [SerializeField] private Button restartB;

    public void HanldeRestartGame()
    {
        OnRestart?.Invoke();
    }
}
