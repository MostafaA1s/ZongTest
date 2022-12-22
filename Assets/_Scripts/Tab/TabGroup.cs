using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
    public List<TabbButton> tabButtons;
    public Sprite tabIdle, tabSelected;
    public TabbButton selectedTab;
    public List<GameObject> TabPages;
    public GameObject menuTutorial;
    public AudioClip menuEff;
    public void Add(TabbButton btn)
    {
        if (tabButtons == null)
        {
            tabButtons = new List<TabbButton>();
        }
        tabButtons.Add(btn);
    }

    public void OnTabHover(TabbButton btn)
    {
        ResetTabs();
        if (selectedTab == null || btn != selectedTab)
            HapticManager.instance.DoHaptic(0.2f, OVRInput.Controller.RHand);

    }

    public void OnTabExit(TabbButton btn)
    {
        ResetTabs();
    }

    public void OnTabPress(TabbButton btn)
    {
        SoundManager.instance.PlayEff(menuEff);
        menuTutorial.SetActive(false);
        selectedTab = btn;
        ResetTabs();
        btn.background.sprite = tabSelected;
        int index = btn.transform.GetSiblingIndex();
        for (int i = 0; i < TabPages.Count; i++)
        {
            if (i == index)
                TabPages[i].SetActive(true);
            else
                TabPages[i].SetActive(false);


        }
    }

    void ResetTabs()
    {
        foreach (TabbButton btn in tabButtons)
        {
            if (selectedTab != null && btn == selectedTab) continue;
            btn.background.sprite = tabIdle;
        }
    }

}
