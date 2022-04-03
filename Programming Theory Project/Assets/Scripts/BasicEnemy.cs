using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    protected Transform player;
    protected GameManager gameManager;
    protected float xRange = 25f;
    [SerializeField] protected float enemySpeed = 10f;
    [SerializeField] protected float maxDistance;
    [SerializeField] protected Vector3 spawnOffset;
    [SerializeField] protected Vector3 rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        InitializeObject();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }
    //ABSTRACTION
    protected virtual void InitializeObject()
    {
        transform.position = player.position + spawnOffset;
    }
    //ABSTRACTION
    public virtual void Move()
    {

    }

    private void CheckBounds()
    {
        if(Vector3.Distance(this.transform.position, player.transform.position) > maxDistance)
        {
            OnDeath();
        }
    }

    public void OnDeath()
    {
        gameManager.CurrentEnemies--;
        Destroy(gameObject);
    }

    public virtual void SpecialMove()
    {

    }
}
