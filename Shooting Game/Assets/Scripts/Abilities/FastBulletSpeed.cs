using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastBulletSpeed : MonoBehaviour
{
    private Bullet bullet;
    private float speedBonus = 1.2f;
        
    public void IncreaseBulletSpeed()
    {
        bullet.GetComponent<Bullet>().currentSpeed *= speedBonus;
    }
}
