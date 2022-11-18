using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteForce : MonoBehaviour, MeteoriteSpawner
{

    [SerializeField] float upForce, sideForce;


    public void OnObjectSpawn()
    {

        float xForce = Random.Range(-sideForce, upForce);
        float yForce = Random.Range(upForce / 3f, upForce);

        Vector3 VelocityMeteoriteForce = new Vector3(xForce, yForce, 0f);

        GetComponent<Rigidbody>().velocity = VelocityMeteoriteForce;

    }

}
