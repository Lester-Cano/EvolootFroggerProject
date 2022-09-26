using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public GameObject player;
    [SerializeField] private Transform spawnPos;

    private void Awake()
    {
        //spawnPos = GameObject.FindGameObjectWithTag("Respawn").transform;

        //int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");

        //GameObject prefab = characterPrefabs[selectedCharacter];
        //GameObject clone = Instantiate(prefab, spawnPos.position, Quaternion.identity);
    }
}
