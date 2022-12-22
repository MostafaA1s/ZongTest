using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenuItem : MonoBehaviour
{
    [SerializeField]
    private Image _icon;
    [SerializeField]
    private Text _name;
    private GameObject _prefab;
    public void SetItem(InventoryItem item)
    {
        _icon.sprite = item.data.itemIcon;
        _name.text = item.data.name;
        _prefab = item.data.prefab;
    }

    public void Equip()
    {
        Player.instance.Epuip(_prefab);
    }
}
