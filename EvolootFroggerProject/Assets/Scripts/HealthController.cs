using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HealthController : MonoBehaviour
{
    public delegate void LifesOver();
    public event LifesOver OnLifesOver;
    public event LifesOver OnLifeLost;

    public GameManager gameManager;
    public PlayerController playerController;
    [SerializeField] private RectTransform[] arrayImgs;
    public bool withoutLives;

    [SerializeField] private int lives = 5;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        playerController = FindObjectOfType<PlayerController>();
    }

    public void OnEnable()
    {
        gameManager.OnRestart += ResetLives;
        playerController.OnLostALive += DecreaseLive;
    }

    public void OnDisable()
    {
        gameManager.OnRestart -= ResetLives;
        playerController.OnLostALive -= DecreaseLive;
    }

    public void DecreaseLive()
    {
        if(lives >= 0)
        {
            arrayImgs[lives - 1].gameObject.SetActive(false);
            lives--;
            OnLifeLost?.Invoke();
        }

        if (lives <= 0)
        {
            OnLifesOver?.Invoke();
            withoutLives = true;
        }
    }

    public void ResetLives()
    {
        withoutLives = false;
        RefillLives();
    }

    public void RefillLives()
    {
        for (int i = 0; i < arrayImgs.Length; i++)
        {
            arrayImgs[i].gameObject.SetActive(true);
        }

        lives = 5;
    }
}
