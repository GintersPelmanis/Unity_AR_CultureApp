using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Item")]
public class Item : ScriptableObject
{
    public string Name;
    public string Description;
    public List<Sprite> Images = new List<Sprite>();
}