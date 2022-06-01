using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHpUpItem : Item
{
    private int MaxHpPoint = 10;
    void Start()
    {
        speed = 8f;
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
        Debug.Log($"최대 체력 증가 아이템");
        GameManager.gameManager.IncreaseMaxHp(MaxHpPoint);
    }
}
