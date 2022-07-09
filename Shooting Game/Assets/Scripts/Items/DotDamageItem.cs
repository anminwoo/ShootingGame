using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotDamageItem : Item
{
    void Start()
    {
        speed = 10f;
    }
    
    void Update()
    {
        Move();
    }
    
    public override void Move()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    public override void UseItem()
    {
        Debug.Log($"도트 데미지 아이템");
        GameManager.gameManager.statusEffectManager.ApplyDotDamage(5);
    }
}
