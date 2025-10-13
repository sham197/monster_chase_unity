using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour
{
    string _gameScene = "Gameplay";
    
    public void PlayGame()
    {
        int selectedCharacter = 
            int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        
        GameManager.instance.CharIndex = selectedCharacter;
            
        SceneManager.LoadScene(_gameScene);
    }
    
} // class
