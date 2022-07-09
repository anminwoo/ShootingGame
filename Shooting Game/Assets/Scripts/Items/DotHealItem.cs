using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotHealItem : Item
{
    void Start()
    {
        speed = 4f;
    }

    public override void Move()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    public override void UseItem()
    {
        Debug.Log("도트힐 아이템");
        GameManager.gameManager.statusEffectManager.ApplyDotHeal(5);
    }
}
