using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private int _hp;
    private int _maxHp;
    public Text hpText; // 현재 남은 체력
    public Text maxHpText; // 최대 체력
    public Slider hpSlider;

    public PlayerController player;
    void Start()
    {
        _hp = player.hp;
        _maxHp = player.maxHp;
        hpText.text = _hp.ToString();
        Debug.Log($"{_hp}");
        maxHpText.text = _maxHp.ToString();
        Debug.Log($"{_maxHp}");
        hpSlider.maxValue = _maxHp;
        hpSlider.value = _maxHp;
    }

    void Update()
    {
        
    }

    void Damaged(int damage)
    {
        player.hp -= damage;
        hpSlider.value = player.hp;
    }

    void Heal(int heal)
    {
        player.hp = player.hp + heal > player.maxHp ? player.maxHp : player.hp + heal;
        hpSlider.value = player.hp;
    }
}
