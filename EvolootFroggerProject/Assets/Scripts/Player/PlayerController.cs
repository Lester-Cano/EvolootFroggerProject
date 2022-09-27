using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public delegate void LostALive();
    public event LostALive OnLostALive;
    public event LostALive OnReachEnd;
    private LvlSounds sfx;

    GameManager gameManager;

    private BoxCollider characterCollider;
    [SerializeField] private Transform spawnPos;

    private bool hitted;

    private void Awake()
    {
        sfx = FindObjectOfType<LvlSounds>();
        characterCollider = GetComponent<BoxCollider>();
        gameManager = FindObjectOfType<GameManager>();
        spawnPos = GameObject.FindGameObjectWithTag("Respawn").transform;
    }

    public void OnEnable()
    {
        gameManager.OnRestart += RestartPlayer;
        gameManager.OnGameOverLost += RestartPlayer;
    }

    public void OnDisable()
    {
        gameManager.OnRestart -= RestartPlayer;
        gameManager.OnGameOverLost -= RestartPlayer;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Danger") && hitted == false)
        {
            hitted = true;
            sfx.DeathByCar();
            StartCoroutine(RestartPlayerHitted());
            OnLostALive?.Invoke();

        }
        else if (other.CompareTag("WinZone"))
        {
            OnReachEnd?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Danger") && hitted == true)
        {
            hitted = false;
        }
    }

    private void RestartPlayer()
    {
        gameObject.transform.position = spawnPos.transform.position;
    }

    private IEnumerator RestartPlayerHitted()
    {
        yield return new WaitForSeconds(0.3f);

        gameObject.transform.position = spawnPos.transform.position;
    }
}
