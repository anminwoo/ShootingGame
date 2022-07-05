using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : Enemy
{
    public override void EnemySetting()
    {
        maxHp         = 50;
        currentHp     = maxHp;
        baseDamage    = 8;
        currentDamage = baseDamage;
        baseSpeed     = 2f;
        currentSpeed  = baseSpeed;
        score         = 300;
        exp           = 5;
        dropChance    = 3;
    }
}
