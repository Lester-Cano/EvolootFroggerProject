using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float MovementDuration=0.15f;
    [SerializeField] private float JumpPower;

    void Start()
    {
        
    }
    void Update()
    {
        Sequence Jump = DOTween.Sequence();
        if (Input.anyKeyDown && (transform.position.x % 1) == 0 && (transform.position.z % 1) == 0)
        {
            if (Input.GetAxis("Horizontal")!= 0 )
            {
                Jump.Insert(0,transform.DOJump(new Vector3(transform.position.x + Mathf.Sign(Input.GetAxis("Horizontal")), transform.position.y, transform.position.z),JumpPower,1, MovementDuration, false));
            }
            else if(Input.GetAxis("Vertical") != 0 )
            {
                Jump.Insert(0,transform.DOJump(new Vector3(transform.position.x , transform.position.y, transform.position.z+ Mathf.Sign(Input.GetAxis("Vertical"))),JumpPower,1, MovementDuration, false));
            }
        }



            
    }
}
