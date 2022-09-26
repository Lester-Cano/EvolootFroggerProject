using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform Target;
    public float speed = 2.0f;

    private void Awake()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float Interpolation = speed * Time.deltaTime;
        Vector3 position = transform.position;
        position.x = Mathf.Lerp(transform.position.x, Target.position.x, Interpolation);
        position.z = Mathf.Lerp(transform.position.z, Target.position.z, Interpolation);
        transform.position = position;
    }
}
