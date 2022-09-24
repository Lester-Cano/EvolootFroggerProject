using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMoving : MonoBehaviour
{
    [SerializeField] public bool directionLeft;
    [SerializeField] private float speed;

    void Update()
    {

        if (directionLeft)
        {
            MoveLeft();
        }
        else
        {
            MoveRight();
        }
        
    }

    void MoveLeft()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
    void MoveRight()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RoadEnd"))
        {
            Debug.Log("cardie");
            gameObject.SetActive(false);
        }
    }
}
