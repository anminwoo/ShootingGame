using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ExpItem : Item
{
    private int expAmount = 5;
    private void Start()
    {
        speed = 6.0f;
    }
    
    private void Update()
    {
        Move();
    }

    public override void Move()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    public override void UseItem()
    {
        GameManager.gameManager.AddExp(expAmount);
    }
}
