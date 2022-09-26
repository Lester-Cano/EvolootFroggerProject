using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void GameOver();
    public event GameOver OnGameOverLost;
    public event GameOver OnGameOverWin;
    public event GameOver OnRestart;
    private LvlSounds sounds;
    private Timer timer;
    private HealthController healthController;
    private PlayerController playerController;
    private PlayerMovement PlayerMovement;

    public GameObject[] characterPrefabs;
    [SerializeField] private Transform spawnPos;

    private void Awake()
    {
        LoadCharacter();

        timer = FindObjectOfType<Timer>();
        sounds = FindObjectOfType<LvlSounds>();
        healthController = FindObjectOfType<HealthController>();
        playerController = FindObjectOfType<PlayerController>();
        PlayerMovement = FindObjectOfType<PlayerMovement>();
    }
    private void OnEnable()
    {
        timer.OnTimeOver += CheckIfLost;
        healthController.OnLifesOver += CheckIfLost;
        playerController.OnReachEnd += HandleWin;
    }
    private void OnDisable()
    {
        timer.OnTimeOver -= CheckIfLost;
        healthController.OnLifesOver -= CheckIfLost;
        playerController.OnReachEnd -= HandleWin;
    }

    public void HanldeRestartGame()
    {
        timer.OnEnable();
        healthController.OnEnable();
        playerController.OnEnable();
        PlayerMovement.OnEnable();
        OnRestart?.Invoke();
    }

    public void HandleGameOver()
    {
        timer.OnDisable();
        timer.StopAllCoroutines();
        healthController.OnDisable();
        playerController.OnDisable();
        PlayerMovement.OnDisable();
        OnGameOverLost?.Invoke();
        sounds.StopAllCoroutines();
    }

    public void HandleWin()
    {
        timer.OnDisable();
        timer.StopAllCoroutines();
        healthController.OnDisable();
        playerController.OnDisable();
        PlayerMovement.OnDisable();
        OnGameOverWin?.Invoke();
        sounds.StopAllCoroutines();
    }

    private void CheckIfLost()
    {
        HandleGameOver();
    }

    private void LoadCharacter()
    {
        spawnPos = GameObject.FindGameObjectWithTag("Respawn").transform;

        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");

        GameObject prefab = characterPrefabs[selectedCharacter];
        GameObject clone = Instantiate(prefab, spawnPos.position, Quaternion.identity);
    }
}
