using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public int damage;
    public float speed;
    public float currentSpeed;

    private CapsuleCollider2D collider;
    public PlayerController player;

    private void Start()
    {
        collider = GetComponent<CapsuleCollider2D>();
        damage = player.baseDamage;
        speed = 10.0f;
        currentSpeed = speed;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        
    }

    void Move()
    {
        transform.Translate(Vector3.up * currentSpeed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}