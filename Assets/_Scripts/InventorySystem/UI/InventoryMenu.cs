using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    public GameObject itemPrefab;
    void Start()
    {
        CreateInv();
        Inventory.instance.OnUpdateInventory += UpdateInventory;
    }


    void UpdateInventory()
    {
        foreach (Transform item in transform)
        {
            Destroy(item.gameObject);
        }
        CreateInv();
    }

    public void CreateInv()
    {
        foreach(InventoryItem item in Inventory.instance.inventoryItems)
        {
            AddInventorySlot(item);
        }
    }

    public void AddInventorySlot(InventoryItem item)
    {
        GameObject obj = Instantiate(itemPrefab);
        obj.transform.SetParent(transform, false);

        InventoryMenuItem menuItem = obj.GetComponent<InventoryMenuItem>();
        menuItem.SetItem(item);
    }


    private void OnDestroy()
    {
        Inventory.instance.OnUpdateInventory -= UpdateInventory;

    }
}
