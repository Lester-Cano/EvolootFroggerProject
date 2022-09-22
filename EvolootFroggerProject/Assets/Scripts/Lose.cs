using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Lose : MonoBehaviour
{
    HealthController healthController;
    [SerializeField] private CanvasGroup group;
    [SerializeField] private RectTransform gameOverRect;
    private void Awake()
    {
        healthController = FindObjectOfType<HealthController>();
    }
    private void OnEnable()
    {
        healthController.OnGameOver += gameOver;
    }
    private void OnDisable()
    {
        healthController.OnGameOver -= gameOver;
    }
    void gameOver()
    {
        group.DOFade(1, 1.5f).SetDelay(0.5f);
        Sequence ShowTitle = DOTween.Sequence();
        ShowTitle.Append(gameOverRect.DOAnchorPos(new Vector2(1028, 529), 1, false));
        ShowTitle.Append(gameOverRect.DOShakeAnchorPos(10, 10, 10, 90, false, false)).SetLoops(2);
    }
}
