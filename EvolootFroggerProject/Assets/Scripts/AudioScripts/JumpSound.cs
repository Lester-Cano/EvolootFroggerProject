using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSound : MonoBehaviour
{
    AudioSource myAudio;
    [SerializeField] AudioClip myClip;
    private void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }
    public void OnJump()
    {
        myAudio.PlayOneShot(myClip);
    }
}
