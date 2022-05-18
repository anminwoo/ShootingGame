using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    public Text hpText; // 현재 남은 체력
    public Text maxHpText; // 최대 체력
    public Slider hpSlider;

    public PlayerController player;
    
    void Start()
    {
        hpText.text = player.hp.ToString();
        Debug.Log($"{player.hp}");
        maxHpText.text = player.maxHp.ToString();
        Debug.Log($"{player.maxHp}");
        hpSlider.maxValue = player.maxHp;
        hpSlider.value = player.maxHp;
    }

    void Update()
    {
        
    }
    
    
}
