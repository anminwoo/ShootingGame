using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player States")]
    public int   currentHp; // 현재 체력
    public int   maxHp; // 최대 체력
    public int   minHp; // 최소 체력
    [Space]
    public int   baseDamage; // 기본 공격력
    public int   currentDamage; // 현재 공격력
    [Space]
    public float baseSpeed; // 기본 이동속도
    public float currentSpeed; // 현재 이동속도

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
