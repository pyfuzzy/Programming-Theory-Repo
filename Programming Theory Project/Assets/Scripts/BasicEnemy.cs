using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    private Transform player;
    private GameManager gameManager;
    [SerializeField] float enemySpeed = 10f;
    [SerializeField] private float maxDistance;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    public virtual void Move()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, player.position, Time.deltaTime * enemySpeed);
    }

    private void CheckBounds()
    {
        if(Vector3.Distance(this.transform.position, player.transform.position) > maxDistance)
        {
            OnDeath();
        }
    }

    public virtual void OnDeath()
    {
        gameManager.CurrentEnemies--;
        Destroy(gameObject);
    }

    public virtual void Attack()
    {

    }
}
