using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cutScene : MonoBehaviour
{
    public AudioManager audioManager;

    public void Awake()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    void Start()
    {
        StartCoroutine(LaunchAnim());
    }

    IEnumerator LaunchAnim()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        if (audioManager != null)
        {
            audioManager.playSound("death");
        }
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene("SampleScene");
    }
}
