using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player States")]
    public int   currentHp;
    public int   maxHp;
    public int   minHp;
    [Space]
    public int   baseDamage;
    public int   currentDamage;
    [Space]
    public float baseSpeed;
    public float currentSpeed;

    public GameObject bullet;

    private void Awake() // PlayerSetting()
    {
        maxHp = 100;
        currentHp = maxHp;
        minHp = 0;
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
