
using UnityEngine;

[CreateAssetMenu(menuName = "item")]

public class InventoryItemData : ScriptableObject
{
    public int id;
    public new string name;
    public Sprite itemIcon;
    public GameObject prefab;

}