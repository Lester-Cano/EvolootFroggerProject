using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMoving : MonoBehaviour
{
    [SerializeField] public bool directionLeftCar;
    [SerializeField] private float speed;

    void Update()
    {

        if (directionLeftCar)
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
            gameObject.SetActive(false);
        }
    }
}
