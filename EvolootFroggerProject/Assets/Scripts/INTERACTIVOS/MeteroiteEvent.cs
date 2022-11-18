using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteroiteEvent : MonoBehaviour
{

    [SerializeField] Transform[] positionsToSpawn;
    [SerializeField] GameObject meteorite;

    private void Start()
    {
       StartCoroutine(SpawnMeteorite());
    }


    IEnumerator SpawnMeteorite()
    {
        Debug.Log("llamado");
        

        while (true)
        {
            int posicionSpawn = Random.Range(0, positionsToSpawn.Length);
            Instantiate(meteorite, positionsToSpawn[posicionSpawn]);
            meteorite.transform.SetParent(null);
            MeteoriteSpawner meteoriteSpawner = meteorite.GetComponent<MeteoriteSpawner>();
            if (meteoriteSpawner != null)
            {
                meteoriteSpawner.OnObjectSpawn();
            }


            yield return new WaitForSeconds(3);
        }
    }


}
