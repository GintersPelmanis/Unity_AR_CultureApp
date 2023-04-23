using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.IO;

public class GalleryImageManager : MonoBehaviour
{
    [SerializeField]
    private GameObject imagePrefab;

    void Start()
    {
        string[] filePaths = Directory.GetFiles(Application.dataPath, "*.png");


        foreach (string filePath in filePaths)
        {
            Debug.Log(filePath);
            // Load the image from the file path
            byte[] bytes = File.ReadAllBytes(filePath);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(bytes);

            // Get the name of the file
            string fileName = Path.GetFileNameWithoutExtension(filePath);

            // Create a new RawImage to display the image
            GameObject imageObject = Instantiate(imagePrefab, this.transform);
            imageObject.name = fileName;
            Rect rec = new Rect(0, 0, texture.width, texture.height);
            imageObject.transform.GetChild(0).GetComponent<Image>().sprite = Sprite.Create(texture, rec, new Vector2(0.5f, 0.5f), 100);
        }
    }
}
