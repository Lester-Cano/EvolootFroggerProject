using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public delegate void TimeOver();
    public event TimeOver OnTimeOver;

    GameManager gameManager;
    [SerializeField] private Image uiFillImage;
    public int remainingDuration;
    public int maxDuration;

    public int Duration { get; private set; }

    private void Awake()
    {
        ResetTimer();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        Begin();
    }

    public void OnEnable()
    {
        gameManager.OnRestart += ResetTimer;
        canTime = true;
    }
    public void OnDisable()
    {
        gameManager.OnRestart -= ResetTimer;
        canTime = false;
    }

    private void ResetTimer()
    {
        uiFillImage.fillAmount = 0f;
        SetDuration(maxDuration);
        Begin();
    }

    private Timer SetDuration(int seconds)
    {
        Duration = remainingDuration = seconds;
        return this;
    }

    private void Begin()
    {
        StopAllCoroutines();
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (remainingDuration >= 0)
        {
            if (remainingDuration == 0)
            {
                TimeIsOver();
            }

            UpdateUI(remainingDuration);
            remainingDuration--;

            yield return new WaitForSeconds(1f);
        }
    }

    private void UpdateUI(int seconds)
    {
        uiFillImage.fillAmount = Mathf.InverseLerp(0, Duration, seconds);
    }

    private void TimeIsOver()
    {
        OnTimeOver?.Invoke();
    }
}
