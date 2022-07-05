using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonEnemy : Enemy
{
    public override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public override void EnemySetting()
    {
        maxHp         = 20;
        currentHp     = maxHp;
        baseDamage    = 5;
        currentDamage = baseDamage;
        baseSpeed     = 3.5f;
        currentSpeed  = baseSpeed;
        score         = 100;
        exp           = 2;
        dropChance    = 2;
    }
}
