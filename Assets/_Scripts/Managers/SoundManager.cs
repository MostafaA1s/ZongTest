using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource music, effects;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayEff(AudioClip clip)
    {
        effects.PlayOneShot(clip);
    }
    public void PlayMusic(AudioClip clip)
    {
        StartCoroutine(StartFade(clip, 1f, 0.6f));
    }

    public IEnumerator StartFade(AudioClip clip, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = music.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            music.volume = Mathf.Lerp(start, 0.1f, currentTime / duration);
            yield return null;
        }
        music.clip = clip;
        currentTime = 0;
        start = music.volume;
        music.Stop();
        music.PlayOneShot(clip);
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            music.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
}
