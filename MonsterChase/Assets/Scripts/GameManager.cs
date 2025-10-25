using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [SerializeField] private GameObject[] characters;
    
    int _charIndex;
    
    private string _gameScene = "Gameplay";
    public int CharIndex
    {
        get { return _charIndex; }
        set { _charIndex = value; }
    }
    
    private void Awake()
    {
       if (instance == null)
       { 
           instance = this;
           DontDestroyOnLoad(gameObject);
       }
       else
       {
           Destroy(gameObject);
       }

    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += onLevelFinishedLoading;
    }
    
    void OnDisable()
    {
        SceneManager.sceneLoaded -= onLevelFinishedLoading;
    }
    
    void onLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == _gameScene)
        {
            Instantiate(characters[_charIndex]);
        }
    }
}
