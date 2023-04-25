using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDetails : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public GameObject imageParent;
    public GameObject imagePrefab;

    private void Start()
    {
        // Retrieve selected item data from PlayerPrefs
        var sceneParamsJson = PlayerPrefs.GetString("ItemDetailsSceneParams");
        Item item = JsonUtility.FromJson<ItemSerializer>(sceneParamsJson).Item;

        // Populate UI with item data
        nameText.text = item.Name;
        descriptionText.text = item.Description;

        //Populate ScrollView with imageprefabs and change sprite in them
        foreach (Sprite image in item.Images)
        {
            var imageObject = Instantiate(imagePrefab, imageParent.transform);
            imageObject.GetComponentInChildren<Image>().sprite = image;
        }
    }
}
