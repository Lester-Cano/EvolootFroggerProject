using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnScene : MonoBehaviour
{
    public List<string> sceneNames;
    public string instanceName;
    // Update is called once per frame
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CheckForDuplicates();
        CheckSceneInList();
    }

    private void CheckForDuplicates()
    {
        DontDestroyOnScene[] collection = FindObjectsOfType<DontDestroyOnScene>();
        foreach (DontDestroyOnScene item in collection)
        {
            if (item != this)
            {
                if (item.instanceName == instanceName)
                {
                    DestroyImmediate(item.gameObject);
                }
            }
        }
    }
    private void CheckSceneInList()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (sceneNames.Contains(currentScene))
        {

        }
        else
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            DestroyImmediate(this.gameObject);
        }
    }
}
