using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private TextMesh scoreTM;
    private PlayerMovement playerMovement;
    private int previousScore;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
        scoreTM = gameObject.GetComponentInChildren<TextMesh>();
    }
    private void OnEnable()
    {
        playerMovement.OnMoved += OnScoreChanged;
    }
    private void OnDisable()
    {
        playerMovement.OnMoved -= OnScoreChanged;
    }

    public void OnScoreChanged(Vector3 NewPLayerPosition)
    {
        Debug.Log("tal");
        int newScore = (int)NewPLayerPosition.z;
        if (previousScore != newScore && newScore >= 0)
        {
            scoreTM.text = (newScore * 10).ToString();
            previousScore = newScore;
        }
    }
}
