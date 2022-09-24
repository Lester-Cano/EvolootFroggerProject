using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMoving : MonoBehaviour
{
    [SerializeField] private bool directionLeft;
    [SerializeField] private float speed;

    // Update is called once per frame
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
        transform.Translate(Vector3.left*speed*Time.deltaTime);
    }
    void MoveRight()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
