using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    GameManager gameManager;
    Restart restartController;
    [SerializeField] private CanvasGroup group;
    [SerializeField] private GameObject winTitle, replayB, menuB;
    [SerializeField] private Transform TitlePos,replayBPos, menuBPos;
    private Transform TitleOldPos, replayBOldPos, menuBOldPos;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        restartController = FindObjectOfType<Restart>();
        TitleOldPos = winTitle.transform;
        replayBOldPos = replayB.transform;
        menuBOldPos = menuB.transform;
    }
    private void OnEnable()
    {
        gameManager.OnGameOverWin += GameOver;
        restartController.OnRestart += OnReset;
    }
    private void OnDisable()
    {
        gameManager.OnGameOverWin -= GameOver;
        restartController.OnRestart -= OnReset;
    }

    public void GameOver()
    {
        //group.gameObject.SetActive(true);
        group.DOFade(1, 1.5f).SetDelay(0.5f);
        TweenToTarget(winTitle, TitlePos);
        TweenToTarget(replayB, replayBPos);
        TweenToTarget(menuB, menuBPos);
    }

    public void OnReset()
    {
        //group.gameObject.SetActive(false);
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
