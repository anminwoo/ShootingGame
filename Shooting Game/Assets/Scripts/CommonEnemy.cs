using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonEnemy : Entity
{
    void Start()
    {
        hp            = maxHp;
        maxHp         = 20;
        baseDamage    = 5;
        currentDamage = baseDamage;
        baseSpeed     = 3f;
        currentSpeed  = baseSpeed;
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
        
    }

    void Move()
    {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
    }
}
