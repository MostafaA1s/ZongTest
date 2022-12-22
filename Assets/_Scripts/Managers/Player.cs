using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public GameObject handModel;
    public GameObject Menu;
    public GameObject rHandContainer,equipedItemRhand;
    public OVRInput.Button menuButton = OVRInput.Button.Start;
    bool menuEnabled;
    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }


    private void Update()
    {
        if(OVRInput.GetDown(menuButton))
        {
            if(menuEnabled)
            {
                CloseMenu();
            }
            else
            {
                OpenMenu();
            }
        }
    }

    public void OpenMenu()
    {
        menuEnabled = true;
        Menu.SetActive(true);
    }

    public void CloseMenu()
    {
        Menu.SetActive(false);
        menuEnabled = false;
    }

    public void Epuip(GameObject item)
    {
        if(equipedItemRhand == null)
        {
            equipedItemRhand = Instantiate(item, rHandContainer.transform);
            handModel.SetActive(false);
        }
        else
        {
            Destroy(equipedItemRhand);
            handModel.SetActive(true);

        }
    }
 
}
