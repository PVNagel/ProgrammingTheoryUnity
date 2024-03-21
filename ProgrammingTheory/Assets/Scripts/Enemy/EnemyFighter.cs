using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFighter : Enemy
{
    protected override void Start()
    {
        base.Start();
        movementSpeed = 20f; // Adjusted speed for the fighter
    }
    // You don't need to override Update or FireMissile if they function the same as the base class.
}