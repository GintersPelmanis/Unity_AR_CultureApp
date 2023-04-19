using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{
    [SerializeField] private GameObject imagePrefab;
    [SerializeField] private Transform content;

    private void Start()
    {
        // Get the path to the directory where the screenshots are saved
        string path = Application.persistentDataPath;

        // Get an array of all PNG files in the directory
        string[] files = Directory.GetFiles(path, "*.png");

        // Loop through the files and create an image for each one
        foreach (string file in files)
        {
            // Load the texture from the file
            Texture2D texture = new Texture2D(2, 2);
            byte[] bytes = File.ReadAllBytes(file);
            texture.LoadImage(bytes);

            // Create a new image object from the prefab
            GameObject imageObject = Instantiate(imagePrefab, content);

            // Set the sprite of the image object to the loaded texture
            imageObject.transform.GetChild(0).GetComponent<Image>().sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        }
    }
}
