using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
        //Loading Check point or new game

    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("checkPoint") == 1)
        {
            Load();
        }
    }

    public void Save()
    {  //save inventory items
        PlayerPrefsExtra.SetList<InventoryItem>("inventoryItems", Inventory.instance.inventoryItems);
        //save player position
        PlayerPrefsExtra.SetVector3("PlayerPosition", GameObject.FindGameObjectWithTag("Player").transform.position);     
    }

    public void Load()
    {
        PlayerPrefs.SetInt("checkPoint", 0);

        //Load Player position
        GameObject.FindGameObjectWithTag("Player").transform.position = PlayerPrefsExtra.GetVector3("PlayerPosition");
        //Load inventory items
        List<InventoryItem> items = PlayerPrefsExtra.GetList<InventoryItem>("inventoryItems");
        foreach (InventoryItem item in items)
        {
            Inventory.instance.AddItem(item.data, item.number);
        }
        Player.instance.OpenMenu();


    }
}
