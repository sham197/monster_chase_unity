using UnityEngine;
using UnityEngine.SceneManagement;
public class GameplayUIController : MonoBehaviour
{
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void quitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
