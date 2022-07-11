using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player States")] 
    public int   revivalChance;
    public int   currentHp; // 현재 체력
    public int   maxHp; // 최대 체력
    public int   minHp; // 최소 체력
    [Space]
    public int   baseDamage; // 기본 공격력
    public int   currentDamage; // 현재 공격력
    public float baseAttackSpeed;
    public float currentAttackSpeed;
    [Space]
    public float baseSpeed; // 기본 이동속도
    public float currentSpeed; // 현재 이동속도
    [Space]
    public int currentExp; // 플레이어의 현재 경험치
    public int requireExp; // 플레이어의 요구 경험치
    public int playerLevel; // 플레이어의 레벨
   
    public GameObject bullet;

    private void Awake() // PlayerSetting()
    {
        revivalChance = 1;
        maxHp         = 100;
        currentHp     = maxHp;
        minHp         = 1;
        baseDamage    = 10;
        currentDamage = baseDamage;
        baseAttackSpeed = 1f;
        currentAttackSpeed = baseAttackSpeed;
        baseSpeed     = 6.0f;
        currentSpeed  = baseSpeed;
        currentExp    = 0;
        requireExp    = 10;
        playerLevel   = 1;
    }
}
