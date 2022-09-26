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

    public void OnEnable()
    {
        gameManager.OnRestart += RestartPlayer;
    }

    public void OnDisable()
    {
        gameManager.OnRestart -= RestartPlayer;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Danger"))
        {
            characterCollider.isTrigger = false;
            RestartPlayer();
            OnLostALive?.Invoke();
            characterCollider.isTrigger = false;
        }
        else if (other.CompareTag("WinZone"))
        {
            OnReachEnd?.Invoke();
        }
    }

    private void RestartPlayer()
    {
        Debug.Log("initial position");
        gameObject.transform.position = spawnPos.transform.position;
    }

}
