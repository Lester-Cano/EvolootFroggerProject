using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HealthController : MonoBehaviour
{
    [SerializeField] private RectTransform[] arrayImgs;
    public delegate void Loose();
    public event Loose OnGameOver;
    void Awake()
    {
        arrayImgs = gameObject.GetComponentsInChildren<RectTransform>(); 
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            DecreaseLive();
        }
    }

    // Update is called once per frame
    public void DecreaseLive()
    {
        for(int i=1;i< arrayImgs.Length ; i++)
        {
            Debug.Log(i);
            if (arrayImgs[i].gameObject.active)
            {
                /*
                RectTransform rect = arrayImgs[i];
                rect.DOShakeAnchorPos(10, 10, 10, 90, false, false);
                */
                arrayImgs[i].gameObject.SetActive(false);
                if(i==arrayImgs.Length-1 && OnGameOver!= null)
                {
                    Debug.Log("gameover");
                    OnGameOver();
                }
                break;
            }
        }
    }
}
