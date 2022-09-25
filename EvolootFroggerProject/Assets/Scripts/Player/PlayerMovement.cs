using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float MovementDuration=0.15f;
    [SerializeField] private float JumpPower;
    [SerializeField] private float ShakePower=0.2f;
    [SerializeField] private float ShakeRandomness = 90;
    [SerializeField] private Ease JumpEase;
    [SerializeField] private Transform playerMesh;
    public delegate void move(float positionZ);
    public event move OnMoved;
    [SerializeField] private float rayCastDistance =2f;
    [SerializeField] private bool grounded =true;
    RaycastHit hit;
    Tweener shakeScale;
    
    void Start()
    {

    }
    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * rayCastDistance, Color.yellow);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down) * rayCastDistance, out hit))
        {
            if (hit.collider.CompareTag("Ground"))
            {
                Debug.Log("tal");
                grounded = true;
            }
        }
    }
    void Update()
    {
        Sequence Jump = DOTween.Sequence();
        if (Input.anyKeyDown && grounded/*&& (transform.position.x % 1) == 0 && (transform.position.z % 1) == 0*/)
        {
            if (Input.GetAxis("Horizontal")!= 0 )
            {
                Jump.Insert(0,transform.DOJump(new Vector3(Mathf.RoundToInt(transform.position.x + Mathf.Sign(Input.GetAxis("Horizontal"))), transform.position.y, Mathf.RoundToInt(transform.position.z)),JumpPower,1, MovementDuration, false)).SetEase(JumpEase);
                Jump.Insert(0, transform.DORotate(new Vector3(0, 90 * Mathf.Sign(Input.GetAxis("Horizontal")), 0), MovementDuration));
                if (shakeScale.IsComplete())
                {
                 playerMesh.DOShakeScale(0.15f,ShakePower*new Vector3(-1,1,-1),1,90,true);
                }

                grounded = false;
            }
            if(Input.GetAxis("Vertical") != 0 )
            {
                float rotationValue;
                if (Mathf.Sign(Input.GetAxis("Vertical")) < 0) rotationValue = 180f;
                else rotationValue = 0f;
                Jump.Insert(0, transform.DORotate(new Vector3(0, rotationValue, 0), MovementDuration));
                Jump.Insert(0,transform.DOJump(new Vector3(Mathf.RoundToInt(transform.position.x) , transform.position.y, Mathf.RoundToInt(transform.position.z+ Mathf.Sign(Input.GetAxis("Vertical")))),JumpPower,1, MovementDuration, false)).SetEase(JumpEase);
                playerMesh.localScale = new Vector3(1, 1, 1);
                if (shakeScale.IsComplete())
                {
                    playerMesh.DOShakeScale(0.15f, ShakePower * new Vector3(-1, 1, -1), 1, 90, true);
                }
                if (OnMoved != null)
                {
                    OnMoved(transform.position.z + Mathf.Sign(Input.GetAxis("Vertical")));
                }
                grounded = false;
            }
            //resetTransform;

        }

    }
    void FeedbackHorizontal()
    {

    }
    void FeedBackVertical()
    {

    }
}
