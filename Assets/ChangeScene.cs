using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void NextScene(string SceneName)
    {
        EditorSceneManager.LoadScene(SceneName);
    }

}
