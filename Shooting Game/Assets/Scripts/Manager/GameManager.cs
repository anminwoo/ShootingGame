using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    
    public UIManager   uiManager;
    public ItemManager itemManager;
    public ButtonManager buttonManager;

    public Player player;

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
            DontDestroyOnLoad(transform.root.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
        itemManager = GameObject.Find("Item Manager").GetComponent<ItemManager>();
        buttonManager = GameObject.Find("Button Manager").GetComponent<ButtonManager>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            uiManager.ControlMenuPanel();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            uiManager.ControlAbilityPanel();
        }
    }
    
    public void HealHp(int heal) // 플레이어가 회복을 받음
    {
        if (player.currentHp + heal > player.maxHp) // 회복량 + 현재 체력이 최대 체력 보다 클 때
        {
            player.currentHp = player.maxHp;
            Debug.Log($"회복량이 플레이어의 최대 체력{player.maxHp}을 넘어 최대체력으로 설정됨.");

        }
        else // 회복량 + 현재 체력이 최대 체력 보다 작을 때
        {
            Debug.Log($"회복 전 플레이어의 체력: {player.currentHp}");
            player.currentHp += heal;
            Debug.Log($"회복 후 플레이어의 체력: {player.currentHp}");
        }
        uiManager.SetHpSlider(player.currentHp);
        uiManager.SetHpText(player.currentHp);
    }
    
    public void GetDamage(int damage) // 플레이어가 데미지를 입음
    {
        Debug.Log($"공격 받기 전 플레이어의 체력: {player.currentHp}"); // 지우기
        if (player.currentHp - damage <= player.minHp) // 플레이어 현재 체력 - 데미지가 최소 체력 보다 작을 때
        {
            // 능력이라던지 특정 아이템 켜기, 사용
            player.currentHp = player.minHp;
            if (player.currentHp == 0)
            {
                // Dead()
                Debug.Log($"플레이어의 체력이 {player.currentHp}이 되어 사망하였습니다."); // 지우기
            }
            // 부활 기능도 추가하면 좋을 듯
            else
            {
                player.currentHp = player.minHp;
                player.minHp = 0;
                Debug.Log($"플레이어의 최소 체력이 {player.minHp}가 되었습니다."); // 지우기
            }
        }
        else
        {
            player.currentHp -= damage;
            Debug.Log($"공격 받은 후 플레이어의 체력: {player.currentHp}"); // 지우기
        }

        uiManager.SetHpSlider(player.currentHp);
        uiManager.SetHpText(player.currentHp);
    }
    
    public void IncreaseDamage(int extraDamage) // 플레이어의 현재 공격력을 올린다.
    {
        player.currentDamage += extraDamage;
    }

    public void DecreaseDamage(int damage) // 플레이어의 현재 공격력을 줄인다.
    {
        // 공격력이 음수가 되지 않도록 처리 필요함
        player.currentDamage -= damage;
    }
    
    public void IncreaseMaxHp(int extraHp) // 플레이어의 최대 체력을 늘린다.
    {
        player.maxHp += extraHp;
        player.currentHp += extraHp; //늘어난 체력만큼 현재 체력에도 추가.
        uiManager.SetHpSlider(player.maxHp, player.currentHp);
        uiManager.SetHpText(player.maxHp, player.currentHp);
    }

    public void DecreaseMaxHp(int lossHp) // 플레이어의 최대체력을 줄인다
    {
        player.maxHp -= lossHp;
        if (player.maxHp <= 0) // 플레이어의 최대 체력 <= 0 이된다면
        {
            player.maxHp = 1; // 최대 체력을 1로 함
        }
        if (player.currentHp > player.maxHp)
        {
            player.currentHp = player.maxHp;
        }
        uiManager.SetHpSlider(player.maxHp, player.currentHp);
        uiManager.SetHpText(player.maxHp, player.currentHp);
    }
    
    public void IncreaseSpeed(float extraSpeed) // 플레이어의 현재 이동속도를 올린다.
    {
        player.currentSpeed += extraSpeed;
    }

    public void DecreaseSpeed(float lossSpeed) // 플레이어의 현재 이동속도를 줄인다.
    {
        // 플레이어 이속이 음수가 되지 않도록 방지 해줘야 할 수도 있다
        player.currentSpeed -= lossSpeed;
        Debug.Log($"플레이어 이속: {player.currentSpeed}"); // 지우기
        if (player.currentSpeed <= 0) // 플레이어의 이속이 0보다 작아지면 0.5로 해줌. 나중에 minSpeed를 넣어주는 것도 좋을 듯.
        {
            player.currentSpeed = 0.5f;
        }
    }

    public void AddExp(int exp)
    {
        player.currentExp += exp;
        Debug.Log($"플레이어의 현재 경험치: {player.currentExp}");
        if (player.currentExp >= player.requireExp)
        {
            LevelUp();
        }
        uiManager.SetExpSlider(player.currentExp);
        uiManager.SetExpText(player.currentExp);
    }
    
    public void LevelUp()
    {
        player.currentExp -= player.requireExp;
        player.playerLevel++;
        uiManager.SetLevelText(player.playerLevel);
        Debug.Log($"레벨업! 플레이어의 현재레벨: {player.playerLevel}, 플레이어의 현재 경험치{player.currentExp}"); // 지우기
        uiManager.ControlAbilityPanel();
    }

    public void SelectAbility()
    {
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;
        Debug.Log($"버튼 이름: {clickObject.name}, 버튼 설명: {clickObject.GetComponentInChildren<Text>().text}");
        uiManager.ControlAbilityPanel();
    }
    
}
