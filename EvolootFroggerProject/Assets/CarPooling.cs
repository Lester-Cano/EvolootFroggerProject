using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPooling : MonoBehaviour
{

    [SerializeField] private GameObject usingCar;
    [SerializeField] private int initialCarNumber = 5;
    [SerializeField] private List<GameObject> carList;
    [SerializeField] Transform[] positions;
    [SerializeField] Transform pool;
    [SerializeField] float timeBetweenCars;
    [SerializeField] float carOffset;

    [SerializeField] bool directionLeft;

    float timer = 0f;


    void Start()
    {
        AddCarsToPool(initialCarNumber);
        SpawnCar();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenCars)
        {
            SpawnCar();
            timer = 0f;
        }
    }

    private void AddCarsToPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject car = Instantiate(usingCar);
            car.SetActive(false);
            carList.Add(car);
            car.transform.parent = pool;
        }
    }

    public GameObject RequestCar()
    {
        for (int i = 0; i < carList.Count; i++)
        {
            if (!carList[i].activeSelf)
            {
                carList[i].SetActive(true);
                return carList[i];
            }
        }
        AddCarsToPool(1);
        carList[carList.Count - 1].SetActive(true);
        return carList[carList.Count - 1];
    }

    void SpawnCar()
    {
        if (directionLeft)
        {
            GameObject car = RequestCar();
            car.gameObject.GetComponent<CarMoving>().directionLeftCar = true;
            car.transform.position = positions[1].transform.position + Vector3.left * carOffset;
        }
        else
        {
            GameObject car = RequestCar();
            car.transform.position = positions[0].transform.position + Vector3.right * carOffset;
        }
    }
}
