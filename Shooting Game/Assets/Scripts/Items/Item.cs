using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected float speed; // 아이템 속도
    public abstract void Move(); // 아이템 이동
    public abstract void UseItem(); // 아이템을 먹었을 때 효과 발동

    private CircleCollider2D collider;


    public void Start()
    {
        collider = GetComponent<CircleCollider2D>();
    }

    public void FixedUpdate()
    {
        Move();
    }

    public void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            UseItem();
            Destroy(gameObject);
        }
    }
}
