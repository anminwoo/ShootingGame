using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowBulletSpeed : MonoBehaviour
{
    private Bullet bullet;
    private float decreaseAmount = 0.8f;
    
    public void DecreaseBulletSpeed()
    {
        bullet.GetComponent<Bullet>().currentSpeed *= decreaseAmount;
    }
}
