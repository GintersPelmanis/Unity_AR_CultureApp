using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ImageNamePasser : MonoBehaviour
{
    
    public void SelectScene()
    {
        SceneManager.LoadScene("Share");
        PlayerPrefs.SetString("ExaminedImage", gameObject.name);

    }
    
}

