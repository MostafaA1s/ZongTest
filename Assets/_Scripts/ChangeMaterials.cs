using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterials : MonoBehaviour
{
    public MeshRenderer[] rend;
    public GameObject[] rayEfect;

    public Material mat;
    public void Start()
    {
        for (int i = 0; i < rend.Length; i++)
        {
            rend[i].material = mat;
            rayEfect[i].SetActive(true);
        }
    }
}
