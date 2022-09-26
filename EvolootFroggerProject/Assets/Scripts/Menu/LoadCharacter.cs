using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    [SerializeField] private Transform spawnPos;

    private void Awake()
    {
        spawnPos = GameObject.FindGameObjectWithTag("Respawn").transform;
    }

    private void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        GameObject prefab = characterPrefabs[selectedCharacter];
        GameObject clone = Instantiate(prefab, spawnPos.position, Quaternion.identity);
    }
}
