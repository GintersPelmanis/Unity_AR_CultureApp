using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDetails : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public Image image;
    static int currentCrown = 1;
    public ItemList itemlist;
    public const int totalCrowns = 2;
    private List<Item> items;
    private Item currentItem;

    private void Start()
    {
        var sceneParamsJson = PlayerPrefs.GetString("ItemDetailsSceneParams");
        currentCrown = JsonUtility.FromJson<ItemSerializer>(sceneParamsJson).number + 1;
        items = itemlist.Items;
        currentItem = items[currentCrown - 1];
        UpdateData();
    }

    public void ChangeCrown(int i)
    {
        currentCrown = (currentCrown + i - 1 + totalCrowns) % totalCrowns + 1;
        currentItem = items[currentCrown - 1];
        UpdateData();
    }

    private void UpdateData()
    {
        nameText.text = currentItem.Name;
        descriptionText.text = currentItem.Description;
        image.sprite = currentItem.Image;
    }

}
