using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    enum ItemNumber
    {
        healItem    = 0,
        maxHpUpItem = 1,
        shieldItem  = 2,
        speedUpItem = 3
    }
    
    public static ItemManager itemManager;
    
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

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    public void DropItem(GameObject gameObject)
    {
        Instantiate(items[(int)ItemNumber.healItem], gameObject.transform.position, gameObject.transform.rotation);
    }
}
