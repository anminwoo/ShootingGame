using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUpItem : Item
{
    private int damagePoint = 2;
    void Start()
    {
        speed = 5f;
    }

    void Update()
    {
        
    }

    public override void Move()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    public override void UseItem()
    {
        Debug.Log($"데미지 증가 아이템"); // 지우기
        Debug.Log($"currentDamage: {GameManager.gameManager.player.currentDamage}"); // 지우기
        GameManager.gameManager.IncreaseDamage(damagePoint);
    }
}
