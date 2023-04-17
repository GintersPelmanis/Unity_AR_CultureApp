using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ItemSerializer{
    public Item Item;
}

public class ItemListUI : MonoBehaviour
{
    [SerializeField]
    public ItemList itemList;
    public Transform itemParent;
    public GameObject itemPrefab;

    private void Start()
    {
        foreach (var item in itemList.Items)
        {
            var itemObject = Instantiate(itemPrefab, itemParent);
            itemObject.GetComponentInChildren<TextMeshProUGUI>().text = item.Name;
            itemObject.GetComponentInChildren<Image>().sprite = item.Images[0];
            itemObject.GetComponent<Button>().onClick.AddListener(() => OnItemClick(item));
        }
    }

    private void OnItemClick(Item item)
    {
        ItemSerializer serializer = new ItemSerializer()
        {
            Item = item
        };

        var sceneParamsJson = JsonUtility.ToJson(serializer);
        SceneManager.LoadScene("CrownInfo");
        PlayerPrefs.SetString("ItemDetailsSceneParams", sceneParamsJson);

    }
}


