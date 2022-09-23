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
    private PlayerMovement playerMovement;
    private int previousScore;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        scoreTM = gameObject.GetComponentInChildren<TMP_Text>();
    }
    private void OnEnable()
    {
        playerMovement.OnMoved += OnScoreChanged;
    }
    private void OnDisable()
    {
        playerMovement.OnMoved -= OnScoreChanged;
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
            scoreRect.DOPunchAnchorPos(new Vector2(0, -60), 0.2f, 5, 1, false);
        }
        else
        {
            scoreRect.DOPunchAnchorPos(new Vector2(0, 60), 0.2f, 5, 1, false);
        }
    }
}
