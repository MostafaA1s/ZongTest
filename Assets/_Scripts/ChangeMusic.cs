using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour
{
    //bool entered;
    public AudioClip clip;
    private void OnTriggerEnter(Collider other)
    {
       // if (entered) return;
       // entered = true;
        if (other.CompareTag("Player"))
            SoundManager.instance.PlayMusic(clip);

    
    }
}
