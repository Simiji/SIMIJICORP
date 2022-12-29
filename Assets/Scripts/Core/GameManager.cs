using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string SceneName;
    public Transform Player;
    #region Singleton
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion


    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        GameMethods.LoadSceneAdditive(SceneName);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene Loaded: " + scene.name);
        
        Transform playerSpawner = GameObject.Find("PlayerSpawner_" + scene.name).transform;
        Player.position = playerSpawner.position;
    }
}
