using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour
{
    string _gameScene = "Gameplay";
    
    public void PlayGame()
    {
        SceneManager.LoadScene(_gameScene);
    }
    
    public void SelectCharacter1()
    {
        
    }
    
    public void SelectCharacter2()
    {
        
    }
} // class
