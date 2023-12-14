using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "New Item/item")]

public class Item : ScriptableObject
{
    public enum ItemType
    {
        Potion,
        Coin,
        Weapon,
        Key,
    }

    public string itemName;
    public ItemType itemType;
    public GameObject itemPrefab;
    // public int itmePrice;
    // public int healAmount;
}
