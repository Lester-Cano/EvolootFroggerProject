using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlSounds : MonoBehaviour
{
    [SerializeField] AudioClip[] SFX;
    GameManager manager;
    private AudioSource mySource;
    private int randomNum;

    private void Awake()
    {
        manager = FindObjectOfType<GameManager>();
    }
    private void Start()
    {
        mySource = GetComponent<AudioSource>();
        StartCoroutine(AHonkWillPlay());
    }
    private void OnEnable()
    {
        manager.OnGameOverWin += Wining;
    }
    private void OnDisable()
    {
        manager.OnGameOverWin -= Wining;
    }
    private void BigCarHonk()
    {
        mySource.PlayOneShot(SFX[1]);
    }
    private void MediumCarHonk()
    {
        mySource.PlayOneShot(SFX[2]);
    }
    private void SmallCarHonk()
    {
        mySource.PlayOneShot(SFX[0]);
    }
    public void DeathByCar()
    {
        mySource.PlayOneShot(SFX[3]);
    }
    public void DeathByWater()
    {
        mySource.PlayOneShot(SFX[4]);
    }
    private void Wining()
    {
        mySource.PlayOneShot(SFX[5]);
        
    }
    private IEnumerator AHonkWillPlay()
    {
        yield return new WaitForSeconds(3.5f);
        randomNum = Random.Range(1, 3);
        switch (randomNum)
        {
            case 1:
                BigCarHonk();
            break;
            case 2:
                SmallCarHonk();
            break;
            case 3:
                MediumCarHonk();
            break;
        }
        StartCoroutine(AHonkWillPlay());
    }
    
}
