using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemList", menuName = "ItemList")]
public class ItemList : ScriptableObject
{
    public List<Item> Items = new List<Item>();
}