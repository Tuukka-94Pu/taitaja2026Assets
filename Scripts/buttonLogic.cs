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
    }
    public void ReturnToMain()
    {
        SceneManager.LoadScene(0);
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
