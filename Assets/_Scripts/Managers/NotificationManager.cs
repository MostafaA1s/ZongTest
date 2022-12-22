using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NotificationManager : MonoBehaviour
{
    public static NotificationManager instance;
    public TMP_Text Msg;
    public GameObject screenCanvas;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }
    public void PushNotification(string msg, AudioClip clip = null)
    {
        screenCanvas.SetActive(true);
        Msg.text = msg;
        if (clip != null)
            SoundManager.instance.PlayEff(clip);
    }
}
