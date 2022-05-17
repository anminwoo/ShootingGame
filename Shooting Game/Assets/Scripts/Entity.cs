using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public int hp; // 체력
    public int maxHp; // 최대 체력
    public int baseDamage; // 공격력
    public int currentDamage; // 현재 공격력
    public float baseSpeed; // 이동속도
    public float currentSpeed;  // 현재 이동속도
}
