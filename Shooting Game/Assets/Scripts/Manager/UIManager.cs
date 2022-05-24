using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text hpText;
    [SerializeField] private Text maxHpText;

    [SerializeField] private Text scoreText;
    
    [SerializeField] private Slider hpSlider;
    
    [SerializeField] private Player player;

    private void Awake()
    {
        
    }

    void Start()
    {
        hpSlider.maxValue = player.maxHp;
        hpSlider.value = player.hp;
    }

    void Update()
    {
        
    }
}
