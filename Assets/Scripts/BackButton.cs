using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    private string sceneName;

    private void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {


            if (Input.GetKey(KeyCode.Escape))
            {
                if (sceneName == "StartScene")
                {
                    Application.Quit();
                }
                if (sceneName == "CrownInfo")
                {
                    SceneManager.LoadScene("StartScene");
                }
                SceneManager.LoadScene("StartScene");
            }


        }
    }
}