using System.Collections;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    public GameObject pauseUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
            if (Input.GetKeyDown(KeyCode.Escape))
            {
            if (pauseUI.activeSelf == false)
            {

                pauseUI.SetActive(true);
            }
            else
            {
                pauseUI.SetActive(false);
            }
                if (Time.timeScale == 1)
             {
                 Time.timeScale = 0;
             }
             else
                {

                Time.timeScale = 1;
             }
       }
    }
}
