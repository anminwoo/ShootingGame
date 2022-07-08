using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSize;
    private float baseSpeed;
    public float currentSpeed;

    private CapsuleCollider2D collider;
    
    
    private void Awake()
    {
        bulletSize = 0.3f;
        baseSpeed = 15.0f;
        currentSpeed = baseSpeed;
        gameObject.transform.localScale = new Vector3(bulletSize, bulletSize);
        collider = GetComponent<CapsuleCollider2D>();
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        transform.Translate(Vector3.up * currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name); // 지우기
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
