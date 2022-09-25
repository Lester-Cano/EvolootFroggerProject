using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StumpsPooling : MonoBehaviour
{

    [SerializeField] private GameObject typeOfStump;
    [SerializeField] private int numberOfStumps;
    [SerializeField] private List<GameObject> stumpList;
    [SerializeField] Transform[] positions;
    [SerializeField] Transform stumpPool;
    [SerializeField] float timeBetweenStumps;
    [SerializeField] float stumpOffset;

    [SerializeField] bool directionLeft;

    float timer = 0f;


    void Start()
    {
        AddStumpsToPool(numberOfStumps);
        SpawnCar();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenStumps)
        {
            SpawnCar();
            timer = 0f;
        }
    }

    private void AddStumpsToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject stump = Instantiate(typeOfStump);
            stump.SetActive(false);
            stumpList.Add(stump);
            stump.transform.parent = stumpPool;
        }
    }

    public GameObject RequestStump()
    {
        for (int i = 0; i < stumpList.Count; i++)
        {
            if (!stumpList[i].activeSelf)
            {
                stumpList[i].SetActive(true);
                return stumpList[i];
            }
        }
        AddStumpsToPool(1);
        stumpList[stumpList.Count - 1].SetActive(true);
        return stumpList[stumpList.Count - 1];
    }

    void SpawnCar()
    {
        GameObject stump = RequestStump();
        if (directionLeft)
        {
            stump.gameObject.GetComponent<CarMoving>().directionLeftCar = true;
            stump.transform.position = positions[1].transform.position + Vector3.left * stumpOffset;
        }
        else
        {
            stump.transform.position = positions[0].transform.position + Vector3.right * stumpOffset;
        }
    }
}
