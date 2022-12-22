using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public Dictionary<InventoryItemData, InventoryItem> items;
    public List<InventoryItem> inventoryItems;
    public UnityAction OnUpdateInventory;
    public AudioClip pickupSound;
    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
        inventoryItems = new List<InventoryItem>();
        items = new Dictionary<InventoryItemData, InventoryItem>();
    }

    public void AddItem(InventoryItemData itemData,int ammount = 1)
    {
        SoundManager.instance.PlayEff(pickupSound);
        if (items.TryGetValue(itemData, out InventoryItem item))
        {
            item.Add();
        }
        else
        {
            InventoryItem newItem = new InventoryItem(itemData);
            inventoryItems.Add(newItem);
            items.Add(itemData, newItem);
        }
        if (ammount == 1)
        {
            OnUpdateInventory?.Invoke();
        }
        else
        {
            ammount--;
            AddItem(itemData, ammount);
        }
    }

    public void RemoveItem(InventoryItemData itemData, int ammount = 1)
    {
        if (items.TryGetValue(itemData, out InventoryItem item))
        {
            item.Remove();
            if (item.number == 0)
            {
                inventoryItems.Remove(item);
                items.Remove(itemData);
            }
            if (ammount == 1)
            {
                OnUpdateInventory?.Invoke();
            }
            else
            {
                ammount--;
                RemoveItem(itemData, ammount);
            }
        }
    }

    public InventoryItem GetItem(InventoryItemData itemData)
    {
        if (items.TryGetValue(itemData, out InventoryItem item))
        {
            return item;
        }
        return null;
    }

  
}
