using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Restart restartController;
    [SerializeField] private Image uiFillImage;
    public int remainingDuration;
    public int maxDuration;

    public int Duration { get; private set; }

    private void Awake()
    {
        ResetTimer();
        restartController = FindObjectOfType<Restart>();
    }

    private void Start()
    {
        Begin();
    }

    private void OnEnable()
    {
        restartController.OnRestart += ResetTimer;
    }
    private void OnDisable()
    {
        restartController.OnRestart -= ResetTimer;
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
        while(remainingDuration > 0)
        {
            UpdateUI(remainingDuration);
            remainingDuration--;
            yield return new WaitForSeconds(1f);
        }
    }

    private void UpdateUI(int seconds)
    {
        uiFillImage.fillAmount = Mathf.InverseLerp(0, Duration, seconds);
    }
}
