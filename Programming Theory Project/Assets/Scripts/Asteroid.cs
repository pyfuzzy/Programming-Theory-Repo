using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class Asteroid : BasicEnemy
{
    //POLYMORPHISM
    public override void Move()
    {
        transform.Rotate(rotateSpeed * Time.deltaTime);
    }

    //POLYMORPHISM
    protected override void InitializeObject()
    {
        spawnOffset = new Vector3(spawnOffset.x + Random.Range(-xRange, xRange),
                        spawnOffset.y, spawnOffset.z);
        transform.position = player.position + spawnOffset;
        rotateSpeed *= Random.Range(-5, 5);
    }
}
