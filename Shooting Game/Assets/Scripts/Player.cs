using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int   hp;
    public int   maxHp;
    public int   baseDamage;
    public int   currentDamage;
    public float baseSpeed;
    public float currentSpeed;

    public GameObject bullet;

    private void Awake()
    {
        hp = 100;
        maxHp = hp;
        baseDamage = 10;
        currentDamage = baseDamage;
        baseSpeed = 10.0f;
        currentSpeed = baseSpeed;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
