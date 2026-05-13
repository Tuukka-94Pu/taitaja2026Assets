using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMan : MonoBehaviour
{
    public AudioManager audioManager;

    public void Awake()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    private void Start()
    {
        audioManager.PlayMusic("menuBg");
    }

    public void Play(int scene)
    {
        Click();
        if(audioManager != null) audioManager.PauseMusic();
        SceneManager.LoadScene(scene);
    }

    public void Quit()
    {
        Click();
        Debug.Log("toimii :D");
        Application.Quit();
    }

    public void Click()
    {
        if (audioManager != null)
        {
            audioManager.PlaySound("click");
        }
        return;
    }
}
