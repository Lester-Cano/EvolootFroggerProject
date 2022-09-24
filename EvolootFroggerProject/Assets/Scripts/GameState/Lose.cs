using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Lose : MonoBehaviour
{
    HealthController healthController;
    GameManager gameManager;
    [SerializeField] private CanvasGroup group;
    [SerializeField] private GameObject winTitle, replayB, menuB;
    [SerializeField] private Transform TitlePos, replayBPos, menuBPos;
    private Transform TitleOldPos, replayBOldPos, menuBOldPos;

    [SerializeField] private RectTransform titleTransform;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        healthController = FindObjectOfType<HealthController>();
        TitleOldPos = winTitle.transform;
        replayBOldPos = replayB.transform;
        menuBOldPos = menuB.transform;
    }
    private void OnEnable()
    {
        gameManager.OnRestart += OnReset;
        gameManager.OnGameOverLost += GameOver;
    }
    private void OnDisable()
    {
        gameManager.OnRestart -= OnReset;
        gameManager.OnGameOverLost -= GameOver;
    }
    public void GameOver()
    {
        group.DOFade(1, 0.5f).SetDelay(1.5f);
        TweenToTarget(winTitle, TitlePos);
        TweenToTarget(replayB, replayBPos);
        TweenToTarget(menuB, menuBPos);

        titleTransform.DOShakeAnchorPos(10, 10, 10, 90, false, false).SetLoops(2).SetDelay(2.1f);
    }

    public void OnReset()
    {
        group.DOFade(0, 1.5f).SetDelay(0.5f);
        TweenToTarget(winTitle, TitleOldPos);
        TweenToTarget(replayB, replayBOldPos);
        TweenToTarget(menuB, menuBOldPos);
    }

    private void TweenToTarget(GameObject target, Transform newPos)
    {
        target.transform.DOMove(newPos.transform.position, 1, false);
    }
}
