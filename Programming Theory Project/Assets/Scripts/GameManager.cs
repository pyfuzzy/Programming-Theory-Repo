using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int maxEnemies;
    [SerializeField] private float spawnRate;
    [SerializeField] GameObject[] enemyPrefabs;
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
    }

    void SpawnEnemy()
    {
        Debug.Log("Spawning Enemy");
        Instantiate(enemyPrefabs[0]);
        _currentEnemies++;
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
