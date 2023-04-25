using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Share : MonoBehaviour
{
    [SerializeField]
    Image preview;
    [SerializeField]
    public ItemList itemList;
    [SerializeField]
    public Toggle toggle;

    private string imageName;
    private string path;
    private string crownText;
    private Item crown;

    private void Start()
    {
        //creating path of image
        imageName = PlayerPrefs.GetString("ExaminedImage");
        path = Path.Combine(Application.persistentDataPath, imageName);

        string[] fileNameParts = imageName.Split('_'); // Split the file name by underscore character

        string crownIdPart = fileNameParts[0]; // Get the first part of the file name
        string crownIdString = crownIdPart.Substring("Vainags".Length); // Remove the "Vainags" prefix
        int.TryParse(crownIdString, out int crownId);

        crown = itemList.Items[crownId];

        // Load the texture from the file
        Texture2D texture = new Texture2D(2, 2);
        byte[] bytes = File.ReadAllBytes(path);
        texture.LoadImage(bytes);

        // Set the sprite of the image object to the loaded texture
        preview.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

        }
    public void ShareButton()
    {
        StartCoroutine(TakeScreenshotAndShare());
    }

    private IEnumerator TakeScreenshotAndShare()
    {
        yield return new WaitForEndOfFrame();

        if (File.Exists(path))
        {
            if (toggle.isOn)
                crownText = crown.Description;
            else
                crownText = "";

            // Share the image using the Unity Native Share plugin
            new NativeShare().AddFile(path)
                .SetSubject("Mans Vainags").SetText(crownText).SetUrl("https://itf.llu.lv")
                .SetCallback((result, shareTarget) => Debug.Log("Shared File"))
                .Share();

        }
        else
        {
            Debug.Log("File not found" + path);
        }

    }
}
