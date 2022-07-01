using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class HealItem : Item
{
    private int healPoint = 30;

    void Start()
    {
        speed = 5f;
    }

    public override void Move()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    public override void UseItem()
    {
        Debug.Log($"회복 아이템");
        GameManager.gameManager.HealHp(healPoint);
    }
}
