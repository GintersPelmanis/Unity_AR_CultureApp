using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ItemSerializer{
    public int number;
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
            
            GameObject image = itemObject.transform.Find("Image").gameObject;

            itemObject.GetComponentInChildren<TextMeshProUGUI>().text = item.Name;
            image.GetComponent<Image>().sprite = item.Image;
            itemObject.GetComponent<Button>().onClick.AddListener(() => OnItemClick(itemList.Items.IndexOf(item)));
        }
    }

    private void OnItemClick(int a)
    {
        ItemSerializer serializer = new()
        {
            number = a
        };

        var sceneParamsJson = JsonUtility.ToJson(serializer);
        SceneManager.LoadScene("CrownInfo");
        PlayerPrefs.SetString("ItemDetailsSceneParams", sceneParamsJson);

    }
}


