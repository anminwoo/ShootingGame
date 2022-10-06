using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemManager : MonoBehaviour
{
    enum ItemNumber
    {
        healItem    = 0,
        maxHpUpItem = 1,
        shieldItem  = 2,
        speedUpItem = 3,
        dotDamageItem = 4,
        dotHealItem = 5
    }
    
    [SerializeField] private Item[] items;
    [Space] 
    [SerializeField] private int itemCount;
    [Header("Item Types")]
    [SerializeField] private Item healItem;
    [SerializeField] private Item maxHpUpItem;
    [SerializeField] private Item shieldItem;
    [SerializeField] private Item speedUpItem;
    [SerializeField] private Item dotDamageItem;
    [SerializeField] private Item dotHealItem;

    private void Awake()
    {
        itemCount = 6;
        healItem    = Resources.Load<Item>("Prefabs/Heal Item");
        maxHpUpItem = Resources.Load<Item>("Prefabs/MaxHpUp Item");
        shieldItem  = Resources.Load<Item>("Prefabs/Shield Item");
        speedUpItem = Resources.Load<Item>("Prefabs/SpeedUp Item");
        dotDamageItem = Resources.Load<Item>("Prefabs/Dot Damage Item");
        dotHealItem = Resources.Load<Item>("Prefabs/Dot Heal Item");
        items = new Item[itemCount];
        items[(int)ItemNumber.healItem]    = healItem;
        items[(int)ItemNumber.maxHpUpItem] = maxHpUpItem;
        items[(int)ItemNumber.shieldItem]  = shieldItem;
        items[(int)ItemNumber.speedUpItem] = speedUpItem;
        items[(int)ItemNumber.dotDamageItem] = dotDamageItem;
        items[(int)ItemNumber.dotHealItem] = dotHealItem;
    }

    public void DropItem(GameObject enemy)
    {
        Instantiate(items[Random.Range(0, itemCount)], enemy.transform.position, enemy.transform.rotation);
    }
}
