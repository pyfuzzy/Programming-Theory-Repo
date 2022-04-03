using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int maxEnemies;
    [SerializeField] private float spawnRate;
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] int playerHP = 10;
    [SerializeField] float levelEnd = 500;
    private GameObject playerObject;
    private int _currentEnemies;
    private float lastSpawnTime;
    private float height;
    private bool showWinScreen = false;
    private bool showLoseScreen = false;
    private string labelText;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        playerObject = GameObject.Find("Player");
    }

    void FixedUpdate()
    {
        if (_currentEnemies < maxEnemies && Time.time - lastSpawnTime > spawnRate)
        {
            SpawnEnemy();
            lastSpawnTime = Time.time;
        }
        height = playerObject.transform.position.y;
        if (height > levelEnd)
        {
            PlayerWon();
        }
    }

    void SpawnEnemy()
    {
        int enemyType;
        Debug.Log("Spawning Enemy");
        enemyType = Random.Range(0, enemyPrefabs.Count);
        Instantiate(enemyPrefabs[enemyType]);
        _currentEnemies++;
    }
    public void PlayerWasHit()
    {
        playerHP--;
        if (playerHP <= 0)
        {
            labelText = "You Lose!";
            showLoseScreen = true;
        }
    }

    private void PlayerWon()
    {
        Debug.Log("Player won the level!");
        labelText = "You Win!!!";
        showWinScreen = true;
    }
    public void PlayerLost()
    {
        Debug.Log("Player Lost!");
        labelText = "Game Over!";
        showLoseScreen = true;
    }
    //ENCAPSULATION
    public int CurrentEnemies
    {
        get { return _currentEnemies; }

        set
        {
            _currentEnemies = value;
            if (_currentEnemies > maxEnemies || _currentEnemies < 0)
                Debug.Log("Invalid Enemy Count!");
        }
    }
    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Player Health: " +
            playerHP);
        GUI.Box(new Rect(20, 50, 150, 25), "Height: " +
            height);

        if (showWinScreen || showLoseScreen)
        {
            Time.timeScale = 0f;
            if (GUI.Button(new Rect(Screen.width / 2 - 100,
               Screen.height / 2 - 50, 200, 100), labelText))
            {
                SceneManager.LoadScene(0);
                Time.timeScale = 1.0f;
            }
        }
    }
}