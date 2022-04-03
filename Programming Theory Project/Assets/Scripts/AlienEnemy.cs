using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class AlienEnemy : BasicEnemy
{
    //POLYMORPHISM
    public override void Move()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, player.position, Time.deltaTime * enemySpeed);
    }
}
