using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private TMP_Text scoreTM;
    [SerializeField] private RectTransform scoreRect;

    [SerializeField] private float feedBackDuration;
    GameManager gm;
    private PlayerMovement playerMovement;
    private int previousScore;
    HealthController healthController;
    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        scoreTM = gameObject.GetComponentInChildren<TMP_Text>();
        healthController = FindObjectOfType<HealthController>();
    }
    private void OnEnable()
    {
        playerMovement.OnMoved += OnScoreChanged;
        healthController.OnLifeLost += ResetScore;
    }
    private void OnDisable()
    {
        playerMovement.OnMoved -= OnScoreChanged;
        healthController.OnLifeLost -= ResetScore;
    }

    public void OnScoreChanged(float positionZ)
    {
        int newScore = (int)positionZ;
        Debug.Log((int)positionZ);
        if (previousScore != newScore && newScore >= 0)
        {
            scoreTM.text = (newScore * 10).ToString();
            ShakeSizeTMP(newScore);
            previousScore = newScore;

        }
    }
    private void ShakeSizeTMP(int newScore)
    {
        if (newScore < previousScore)
        {
            scoreRect.DOComplete();
            scoreRect.DOPunchAnchorPos(new Vector2(0, -60), 0.2f, 5, 1, false);
        }
        else
        {
            scoreRect.DOComplete();
            scoreRect.DOPunchAnchorPos(new Vector2(0, 60), 0.2f, 5, 1, false);
        }
    }
    private void ResetScore()
    {
        scoreTM.text = 0.ToString();
    }
}
