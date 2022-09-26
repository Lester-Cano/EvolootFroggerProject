using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stump : MonoBehaviour
{
   [SerializeField] float speed,lifeTime;
    GameObject player;
    private float timer;
    public bool directionStump;
    private void Update()
    {
        if (directionStump)
        {
            MoveLeft();
        }
        else
        {
            MoveRight();
        }
        if (timer > lifeTime)
        {
            player.transform.SetParent(null);
            this.gameObject.SetActive(false);
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("me garcharon");
            player = collision.gameObject;
            player.transform.SetParent(transform);
            
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("me bugee");
            player = collision.gameObject;
            player.transform.SetParent(null);     
            
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            timer += Time.deltaTime;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {   
            
            if (other.CompareTag("RoadEnd"))
            {
                Debug.Log("buenas");
                gameObject.SetActive(false);
            }
    }

}
