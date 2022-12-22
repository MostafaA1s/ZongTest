using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandInteractor : MonoBehaviour
{
    public OVRInput.Button joyPadClickButton = OVRInput.Button.SecondaryIndexTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("interactable"))
        {
            other.TryGetComponent<ItemGrabable>(out ItemGrabable item);
            item.OnHover();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("interactable"))
        {
            if (OVRInput.GetDown(joyPadClickButton))
            {
                other.TryGetComponent<ItemGrabable>(out ItemGrabable item);
                item.OnPick();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("interactable"))
        {
            other.TryGetComponent<ItemGrabable>(out ItemGrabable item);
            item.OnUnHover();
        }
    }
}
