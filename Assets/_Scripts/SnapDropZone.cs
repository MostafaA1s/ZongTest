using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SnapDropZone : MonoBehaviour
{
    public string DropItemTag,boxName;
    public GameObject highlight;
    public GameObject Effect;
    public AudioClip effClip;
    public AudioClip newMusic;

    public OVRInput.Button interactButton = OVRInput.Button.SecondaryIndexTrigger;
    public bool isCBox;
    bool entered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(DropItemTag) && !entered)
        {
            entered = true;
            HapticManager.instance.DoHaptic(0.4f, OVRInput.Controller.RHand);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(DropItemTag))
        {
            if (OVRInput.GetDown(interactButton))
            {
                highlight.SetActive(false);
                other.transform.parent = null;
                Inventory.instance.RemoveItem(other.GetComponent<Item>().data);
                other.transform.position = highlight.transform.position;
                other.transform.rotation = highlight.transform.rotation;
                if (isCBox)
                {
                    PlayerPrefs.SetInt("checkPoint", 1);
                    ScenesManager.instance.LoadScene(1);
                    return;
                }

                Effect?.SetActive(true);
                SoundManager.instance.PlayEff(effClip);
                SoundManager.instance.PlayMusic(newMusic);

                NotificationManager.instance.PushNotification("you have dropped in " + boxName);

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(DropItemTag))
        {
            entered = false;
        }
    }
}
