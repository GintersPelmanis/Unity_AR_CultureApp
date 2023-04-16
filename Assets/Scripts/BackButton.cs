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

    private void PrevScene()
    {
        SceneStack.Pop();
        if (SceneStack.Count > 0)
            SceneManager.LoadScene(SceneStack.Peek());
        else
            Application.Quit();
    }
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android && Input.GetKey(KeyCode.Escape))
            PrevScene();
    }
}