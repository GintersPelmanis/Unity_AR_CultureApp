using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Delete : MonoBehaviour
{
    private string imageName;
    private string path;

    [SerializeField]
    GameObject popup;

    private void Start()
    {
        imageName = PlayerPrefs.GetString("ExaminedImage");
        path = Path.Combine(Application.persistentDataPath, imageName);
    }
    public void DeleteButton()
    {
        if (File.Exists(path))
        {
            popup.SetActive(true);
            File.Delete(path);
            SceneManager.LoadScene("Gallery");
        }
        else
        {
            Debug.Log("File not found" + path);
        }
    }
}

