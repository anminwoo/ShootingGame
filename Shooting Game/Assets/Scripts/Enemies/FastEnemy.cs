using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemy : Enemy
{
    public override void EnemySetting()
    {
        maxHp         = 15;
        currentHp     = maxHp;
        baseDamage    = 10;
        currentDamage = baseDamage;
        baseSpeed     = 5f;
        currentSpeed  = baseSpeed;
        score         = 150;
        exp           = 2;
        dropChance    = 1;
    }
}
