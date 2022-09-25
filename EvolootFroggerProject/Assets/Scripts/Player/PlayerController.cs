using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public delegate void LostALive();
    public event LostALive OnLostALive;
    public event LostALive OnReachEnd;

    GameManager gameManager;

    private BoxCollider characterCollider;
    [SerializeField] public Transform spawnPos;

    private void Awake()
    {
        characterCollider = GetComponent<BoxCollider>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnEnable()
    {
        gameManager.OnRestart += RestartPlayer;
    }

    private void OnDisable()
    {
        gameManager.OnRestart -= RestartPlayer;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Danger"))
        {
            RestartPlayer();
            OnLostALive?.Invoke();
        }
        else if (other.CompareTag("WinZone"))
        {
            OnReachEnd?.Invoke();
        }
    }

    private void RestartPlayer()
    {
        gameObject.transform.position = spawnPos.transform.position;
    }
}
