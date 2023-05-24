using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Weapon
{
    public override void Move()
    {
        base.Move();
        transform.position = Vector3.MoveTowards(tF.position, direction, speed);
    }
}
