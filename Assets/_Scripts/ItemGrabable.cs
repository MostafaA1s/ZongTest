using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGrabable : MonoBehaviour
{
    public InventoryItemData itemData;
    public bool openMenu;
    private void Start()
    {
        if (PlayerPrefs.GetInt("checkPoint") == 1)
        {
            Destroy(gameObject);
        }
    }
    public void OnPick()
    {
        if (openMenu)
            Player.instance.OpenMenu();
        Inventory.instance.AddItem(itemData);
        SaveManager.instance.Save();
        HapticManager.instance.DoHaptic(0.2f, OVRInput.Controller.RHand);
        Destroy(gameObject);
    }

    public void OnHover()
    {
        Debug.Log("HOVER");
    }

    public void OnUnHover()
    {
        Debug.Log("UnHOVER");

    }
}
