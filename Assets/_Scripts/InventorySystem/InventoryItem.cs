
using System;
using UnityEngine;

[Serializable]
public class InventoryItem
{
    public InventoryItemData data;
    public int number;

    public InventoryItem(InventoryItemData itemData)
    {
        data = itemData;
        Add();
    }

    public void Add()
    {
        number++;
    }

    public void Remove()
    {
        number--;
    }

}
