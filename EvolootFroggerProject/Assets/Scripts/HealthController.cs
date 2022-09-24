using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HealthController : MonoBehaviour
{
    [SerializeField] private RectTransform[] arrayImgs;
    public GameManager gameManager;
    public bool withoutLives;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        arrayImgs = gameObject.GetComponentsInChildren<RectTransform>(); 
    }

    private void OnEnable()
    {
        gameManager.OnRestart += ResetLives;
    }

    private void OnDisable()
    {
        gameManager.OnRestart += ResetLives;
    }

    public void DecreaseLive()
    {
        for(int i = 1; i < arrayImgs.Length; i++)
        {
            if (arrayImgs[i].gameObject.activeInHierarchy)
            {
                arrayImgs[i].gameObject.SetActive(false);

                if(i == arrayImgs.Length - 1)
                {
                    withoutLives = true;
                }

                break;
            }
        }
    }

    public void ResetLives()
    {
        withoutLives = false;
        RefillLives();
    }

    public void RefillLives()
    {
        for (int i = 1; i < arrayImgs.Length; i++)
        {
            arrayImgs[i].gameObject.SetActive(true);
        }
    }
}
