using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float MovementDuration;
    [SerializeField] private float JumpPower;
    [SerializeField] private float ShakePower;
    [SerializeField] private float ShakeRandomness;
    [SerializeField] private Ease JumpEase;
    [SerializeField] private Transform playerMesh;
    private JumpSound jump;
    public delegate void move(float positionZ);
    public event move OnMoved;
    [SerializeField] private float rayCastDistance;
    [SerializeField] private bool grounded = true;
    private float yStartPosition;
    RaycastHit hit;
    Tweener shakeScale;

    private bool canMove;
    


    void Start()
    {
        yStartPosition = transform.position.y;
        jump = GetComponent<JumpSound>();
    }

    public void OnEnable()
    {
        canMove = true;
    }
    public void OnDisable()
    {
        canMove = false;
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down).normalized * rayCastDistance, out hit))
        {
            if (hit.collider.CompareTag("Ground"))
            {
                grounded = true;
            }
        }
    }
    void Update()
    {
        if (Input.anyKeyDown && grounded && canMove)
        {
            MoveChar();
        }
       
    }
    void FeedbackMovent()
    {
        if (playerMesh.transform.localScale != new Vector3(1, 1, 1))
        {
            playerMesh.DOComplete(false);
            playerMesh.transform.localScale = new Vector3(1, 1, 1);
        }
        playerMesh.DOShakeScale(0.15f, ShakePower * new Vector3(-1, 1, -1), 1, 90, true).SetDelay(MovementDuration);
        grounded = false;
    }


    private void MoveChar()
    {
        grounded = false;

        Sequence Jump = DOTween.Sequence();
        jump.OnJump();
        if (Input.GetAxis("Horizontal") != 0)
        {
            Jump.Insert(0, transform.DORotate(new Vector3(0, 90 * Mathf.Sign(Input.GetAxis("Horizontal")), 0), MovementDuration));
            if (transform.position.y >= yStartPosition) Jump.Insert(0, transform.DOJump(new Vector3(Mathf.RoundToInt(transform.position.x + Mathf.Sign(Input.GetAxis("Horizontal"))), yStartPosition, Mathf.RoundToInt(transform.position.z)), JumpPower, 1, MovementDuration, false)).SetEase(JumpEase);
            else
            {
                Jump.Insert(0, transform.DOJump(new Vector3(Mathf.RoundToInt(transform.position.x + Mathf.Sign(Input.GetAxis("Horizontal"))), transform.position.y, Mathf.RoundToInt(transform.position.z)), JumpPower, 1, MovementDuration, false)).SetEase(JumpEase);
            }
            FeedbackMovent();
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            float rotationValue;

            if (Mathf.Sign(Input.GetAxis("Vertical")) < 0) rotationValue = 180f;
            else rotationValue = 0f;
            Jump.Insert(0, transform.DORotate(new Vector3(0, rotationValue, 0), MovementDuration));
            if (transform.position.y >= yStartPosition)
            {
                Jump.Insert(0, transform.DOJump(new Vector3(Mathf.RoundToInt(transform.position.x), yStartPosition, Mathf.RoundToInt(transform.position.z + Mathf.Sign(Input.GetAxis("Vertical")))), JumpPower, 1, MovementDuration, false)).SetEase(JumpEase);
            }
            else
            {
                Jump.Insert(0, transform.DOJump(new Vector3(Mathf.RoundToInt(transform.position.x), transform.position.y, Mathf.RoundToInt(transform.position.z + Mathf.Sign(Input.GetAxis("Vertical")))), JumpPower, 1, MovementDuration, false)).SetEase(JumpEase);
            }
            FeedbackMovent();
            if (OnMoved != null)
            {
                OnMoved(transform.position.z + Mathf.Sign(Input.GetAxis("Vertical")));
            }
        }
    }
}
