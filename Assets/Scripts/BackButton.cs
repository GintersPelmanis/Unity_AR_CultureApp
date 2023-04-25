using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public static Stack<string> SceneStack = new Stack<string>();
    private string currentScene;

    private void Start()
    {
        Debug.Log(SceneStack.Count);
        currentScene = SceneManager.GetActiveScene().name;
        SceneStack.Push(currentScene);
    }

    public void PrevScene()
    {
        if (SceneStack.Count > 1)
        {
            SceneStack.Pop();
            SceneManager.LoadScene(SceneStack.Pop());
        }
        else
        {
            Application.Quit();
        }
    }


    void Update()
    {
        if (Application.platform == RuntimePlatform.Android && Input.GetKey(KeyCode.Escape))
            PrevScene();
    }
}