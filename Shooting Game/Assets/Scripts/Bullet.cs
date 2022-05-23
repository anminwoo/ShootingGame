using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float baseSpeed;
    private float currentSpeed;

    private CapsuleCollider2D collider;
    
    
    private void Awake()
    {
        baseSpeed = 15.0f;
        currentSpeed = baseSpeed;
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
        Debug.Log(col.gameObject.name);
    }
}
