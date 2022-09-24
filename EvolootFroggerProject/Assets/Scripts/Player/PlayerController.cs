using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public delegate void LostALive();
    public event LostALive OnLostALive;
    public event LostALive OnReachEnd;

    private BoxCollider characterCollider;
    [SerializeField] public Transform spawnPos;

    private void Awake()
    {
        characterCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Danger"))
        {
            OnLostALive?.Invoke();
            transform.position = spawnPos.transform.position;
        }
        else if (other.CompareTag("WinZone"))
        {
            OnReachEnd?.Invoke();
        }
    }
}
