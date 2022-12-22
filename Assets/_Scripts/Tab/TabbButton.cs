using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class TabbButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private TabGroup tabGroup;
    public Image background;

    public void OnPointerClick(PointerEventData eventData)
    {
        tabGroup.OnTabPress(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tabGroup.OnTabHover(this);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tabGroup.OnTabExit(this);

    }

    // Start is called before the first frame update
    void Start()
    {
        tabGroup = transform.GetComponentInParent<TabGroup>();
        tabGroup.Add(this);

        background = GetComponent<Image>();
    }


}
