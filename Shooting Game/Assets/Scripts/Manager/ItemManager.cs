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
        speedUpItem = 3
    }
    
    [SerializeField] private Item[] items;
    [Space] 
    [SerializeField] private int itemCount;
    [Header("Item Types")]
    [SerializeField] private Item healItem;
    [SerializeField] private Item maxHpUpItem;
    [SerializeField] private Item shieldItem;
    [SerializeField] private Item speedUpItem;

    private void Awake()
    {
        itemCount = 4;
        healItem    = Resources.Load<Item>("Prefabs/Heal Item");
        maxHpUpItem = Resources.Load<Item>("Prefabs/MaxHpUp Item");
        shieldItem  = Resources.Load<Item>("Prefabs/Shield Item");
        speedUpItem = Resources.Load<Item>("Prefabs/SpeedUp Item");
        items = new Item[itemCount];
        items[(int)ItemNumber.healItem]    = healItem;
        items[(int)ItemNumber.maxHpUpItem] = maxHpUpItem;
        items[(int)ItemNumber.shieldItem]  = shieldItem;
        items[(int)ItemNumber.speedUpItem] = speedUpItem;
    }

    public void DropItem(GameObject enemy)
    {
        Instantiate(items[Random.Range(0, itemCount)], enemy.transform.position, enemy.transform.rotation);
    }
}
