using UnityEngine;


public class GameManager : MonoBehaviour
{
    public GameObject deathUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnDeath()
    {
        Time.timeScale = 0;
        deathUI.SetActive(true);
    }
}
