using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
   [SerializeField] private GameManager myManager;
    private AudioSource mySource;
    [SerializeField] AudioClip[] bgMusic;

    private void Awake()
    {
        mySource = GetComponent<AudioSource>();
        
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneloaded;
        
    }
   
    private void OnLosing()
    {
        mySource.clip = bgMusic[2];
        mySource.Play();
    }
    private void OnSceneloaded(Scene scene, LoadSceneMode mode)
    {
        if (myManager == null)
        {
            myManager = FindObjectOfType<GameManager>();
            
        }
        if (myManager != null)
        {
            myManager.OnGameOverLost += OnLosing;
            myManager.OnRestart += OnReset;
        }
        if (scene.name == "MainMenu" && mySource != null)
        {
            mySource.clip = bgMusic[0];
            mySource.Play();
        }
        if ((scene.name == "Testeo" || scene.name == "MainScene") && mySource != null)
        {
            mySource.clip = bgMusic[1];
            mySource.Play();
        }
    }
    private void OnReset()
    {
        mySource.clip = bgMusic[1];
        mySource.Play();
    }
}
