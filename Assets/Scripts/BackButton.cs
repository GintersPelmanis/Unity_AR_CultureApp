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
        currentScene = SceneManager.GetActiveScene().name;
        SceneStack.Push(currentScene);
    }

    public void PrevScene()
    {
        SceneStack.Pop();
        if (SceneStack.Count > 1)
            SceneManager.LoadScene(SceneStack.Pop());
        else
            Application.Quit();
    }


    void Update()
    {
        if (Application.platform == RuntimePlatform.Android && Input.GetKey(KeyCode.Escape))
            PrevScene();
    }
}