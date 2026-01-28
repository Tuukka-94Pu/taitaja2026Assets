using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonLogic : MonoBehaviour
{
   //All methods used by buttons onClick are here

    public void ExitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
    }
    public void ReturnToMain()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }
}
