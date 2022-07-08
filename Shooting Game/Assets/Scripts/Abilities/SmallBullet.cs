using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBullet : MonoBehaviour
{
    private Bullet bullet;
    private Player player;
    private float amount = 0.65f;
    private int damageBonus = 5;
    
    public void Decrease()
    {
        bullet.GetComponent<Bullet>().bulletSize *= amount;
        player.GetComponent<Player>().currentDamage += 5;
    }
}
