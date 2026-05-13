using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonLogic : MonoBehaviour
{
    public void toMain()
    {
        SceneManager.LoadScene("Menu");
    }
    public void quitDisShit()
    {
        Application.Quit();
    }
    public void toGame()
    {
        SceneManager.LoadScene("Tilesety");
    }

}
