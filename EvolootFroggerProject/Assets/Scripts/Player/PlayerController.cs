using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public delegate void LostALive();
    public event LostALive OnLostALive;

    public BoxCollider characterCollider;

    private void Awake()
    {
        characterCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Danger"))
        {
            OnLostALive?.Invoke();
        }
    }
}
