using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.Find("Player");
    }

    void FixedUpdate()
    {
        if (_currentEnemies < maxEnemies && Time.time - lastSpawnTime > spawnRate )
        {
            SpawnEnemy();
            lastSpawnTime = Time.time;
        }
        if(playerObject.transform.position.y > levelEnd)
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
        if(playerHP<=0)
        {
            Debug.Log("Game Over");
        }
    }

    private void PlayerWon()
    {
        Debug.Log("Player won the level!");

    }
    //ENCAPSULATION
    public int CurrentEnemies
    {
        get { return _currentEnemies; }

        set { _currentEnemies = value;
            if (_currentEnemies > maxEnemies || _currentEnemies < 0)
                Debug.Log("Invalid Enemy Count!");
            }
    }
}
