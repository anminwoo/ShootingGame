using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBullet : MonoBehaviour
{
    private Bullet bullet;

    private float amount = 1.25f;
    
    public void Increase()
    {
        bullet.GetComponent<Bullet>().bulletSize *= amount;
    }
}
