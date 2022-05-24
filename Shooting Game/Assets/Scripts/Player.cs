using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player States")]
    public int   hp;
    public int   maxHp;
    [Space]
    public int   baseDamage;
    public int   currentDamage;
    [Space]
    public float baseSpeed;
    public float currentSpeed;

    public GameObject bullet;

    private void Awake() // PlayerSetting()
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
