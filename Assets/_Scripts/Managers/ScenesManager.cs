using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager instance;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }
    public void LoadScene(int index)
    {
        //PlayerPrefs.SetInt("checkPoint", 0);
        SceneManager.LoadScene(index);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
