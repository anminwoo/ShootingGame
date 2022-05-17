using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

class EnemyController : MonoBehaviour
{
    private float speed = 10.0f;
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
        
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        h = h * speed * Time.deltaTime;
        v = v * speed * Time.deltaTime;
        
        transform.Translate(Vector3.left * h);
        transform.Translate(Vector3.down * v);
    }
}
