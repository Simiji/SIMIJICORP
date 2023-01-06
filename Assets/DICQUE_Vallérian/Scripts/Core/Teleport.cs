using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        GameMethods.LoadSceneAdditive(sceneName);
    }
    public void UnloadScene(string sceneName)
    {
        GameMethods.UnloadScene(sceneName);
    }
}
