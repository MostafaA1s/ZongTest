using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticManager : MonoBehaviour
{
    public static HapticManager instance;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }


    public void DoHaptic(float t, OVRInput.Controller controller)
    {
        StartCoroutine(StartHaptic(t, controller));
    }

    IEnumerator StartHaptic(float t, OVRInput.Controller controller)
    {
        OVRInput.SetControllerVibration(0, 0, controller);

        OVRInput.SetControllerVibration(0.5f, 0.5f, controller);
        yield return new WaitForSeconds(t);
        OVRInput.SetControllerVibration(0, 0, controller);

    }
}
